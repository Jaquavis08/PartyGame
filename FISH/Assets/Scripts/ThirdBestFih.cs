using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
PSEUDOCODE / PLAN:
1. On Start and every Update call GetScore().
2. In GetScore():
   - If Score reference is null, log warning and return.
   - Create a list to hold (playerNumber, score) for every found PlayerJoin.
   - For each PlayerJoin found:
       - Map player.playerNumber to the corresponding score field from Score.
       - If mapping succeeds, add (playerNumber, score) to the list.
   - After collecting all players, sort the list by score descending.
   - If there are at least 3 entries:
       - Select the third entry (index 2) as the third best player.
       - Call DisplayFishyyy with that playerNumber.
     Else:
       - Hide all fish and log that there aren't enough players.
3. In DisplayFishyyy(int playerNumber):
   - Deactivate all fish in BestFishyyy safely.
   - Compute index = playerNumber - 1.
   - If index is within bounds, activate the corresponding fish.
   - Otherwise do nothing (or log).
*/

public class ThirdBestFish : MonoBehaviour
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

        if (playerScores.Count < 3)
        {
            // Not enough players to determine a third place.
            Debug.Log("Less than three players found; cannot determine third best.");
            HideAllFish();
            return;
        }

        // Order by score descending and take the third item (index 2).
        var ordered = playerScores.OrderByDescending(p => p.score).ToList();
        var thirdBest = ordered[2];

        Debug.Log($"Player {thirdBest.playerNumber} is third with score: {thirdBest.score}");
        DisplayFishyyy(thirdBest.playerNumber);
    }

    void HideAllFish()
    {
        if (BestFishyyy == null) return;
        BestFishyyy.ForEach(fish =>
        {
            if (fish != null)
                fish.SetActive(false);
        });
    }

    void DisplayFishyyy(int playerNumber)
    {
        // Deactivate all first
        HideAllFish();

        if (BestFishyyy == null)
        {
            Debug.LogWarning("BestFishyyy list is null.");
            return;
        }

        int index = playerNumber - 1;
        if (index < 0 || index >= BestFishyyy.Count)
        {
            Debug.LogWarning($"Player number {playerNumber} does not have a corresponding fish entry.");
            return;
        }

        var fishToShow = BestFishyyy[index];
        if (fishToShow != null)
            fishToShow.SetActive(true);
    }
}
