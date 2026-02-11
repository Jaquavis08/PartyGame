using System.Collections.Generic;
using UnityEngine;

public class BestFish : MonoBehaviour
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

        int bestScore = int.MinValue;
        int bestPlayer = -1;

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

            if (playerScore > bestScore)
            {
                bestScore = playerScore;
                bestPlayer = player.playerNumber;
            }
            DisplayFishyyy(bestPlayer);
        }

        if (bestPlayer != -1)
        {
            Debug.Log($"Player {bestPlayer} has the highest score: {bestScore}");
        }
        else
        {
            Debug.Log("No players found to evaluate scores.");
        }
    }

    void DisplayFishyyy(int playerNumber)
    {
        print(playerNumber);
        BestFishyyy.ForEach(fish => fish.SetActive(false));

        switch (playerNumber - 1)
        {
            case 0: 
                BestFishyyy[0].SetActive(true);
                break;
            case 1:
                BestFishyyy[1].SetActive(true);
                break;
            case 2:
                BestFishyyy[2].SetActive(true);
                break;
            case 3:
                BestFishyyy[3].SetActive(true);
                break;
        }
    }
}
