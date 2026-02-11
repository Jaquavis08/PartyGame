    using System.Collections.Generic;
    using UnityEngine;

    public class SecondBestFih : MonoBehaviour
    {
        public GameScore Score;
        public List<GameObject> BestFishyyy;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            GetScore();
        }

        public void Update()
        {
            GetScore();
        }

        void GetScore()
        {
            if (Score == null)
            {
                Debug.LogWarning("Score reference is null on BestFish.");
                return;
            }

            if (BestFishyyy == null)
            {
                Debug.LogWarning("BestFishyyy list is null on BestFish.");
                return;
            }

            var playerScores = new List<(int playerNumber, int score)>();

            foreach (PlayerJoin player in FindObjectsByType<PlayerJoin>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                int playerScore;
                switch (player.playerNumber)
                {
                    case 1:
                        playerScore = Score.playerScore1;
                        break;
                    case 2:
                        playerScore = Score.playerScore2;
                        break;
                    case 3:
                        playerScore = Score.playerScore3;
                        break;
                    case 4:
                        playerScore = Score.playerScore4;
                        break;
                    default:
                        continue;
                }

                playerScores.Add((player.playerNumber, playerScore));
            }

            if (playerScores.Count == 0)
            {
                Debug.Log("No players found to evaluate scores.");
                DisableAllFish();
                return;
            }

            // Sort descending by score
            playerScores.Sort((a, b) => b.score.CompareTo(a.score));

            if (playerScores.Count < 2)
            {
                // No second-best available
                Debug.Log("Less than two players present; no second-best to display.");
                DisableAllFish();
                return;
            }

            var secondBest = playerScores[1];
            Debug.Log($"Player {secondBest.playerNumber} is second best with score: {secondBest.score}");
            DisplayFishyyy(secondBest.playerNumber);
        }

        void DisplayFishyyy(int playerNumber)
        {
            // Normalize and safety checks
            BestFishyyy.ForEach(fish => fish.SetActive(false));

            if (playerNumber <= 0)
            {
                return;
            }

            int index = playerNumber - 1;
            if (index >= 0 && index < BestFishyyy.Count)
            {
                BestFishyyy[index].SetActive(true);
            }
            else
            {
                Debug.LogWarning($"Player number {playerNumber} does not map to an index in BestFishyyy.");
            }
        }

        void DisableAllFish()
        {
            if (BestFishyyy == null)
                return;

            BestFishyyy.ForEach(fish => fish.SetActive(false));
        }
    }