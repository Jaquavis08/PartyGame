using System.Collections.Generic;
using UnityEngine;

public class BestFish : MonoBehaviour
{
    public GameScore Score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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

        foreach (PlayerJoin player in FindObjectsOfType<PlayerJoin>())
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
}
