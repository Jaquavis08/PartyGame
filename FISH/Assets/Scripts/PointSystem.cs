using System.Diagnostics.CodeAnalysis;
using Unity.Collections;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public static PointSystem Instance;
    public GameScore gameScore;

    public void Awake()
    {
        Instance = this;
    }

    
    public void Playerscore (GameObject playerName, int pointsToAdd)
    {
        print(playerName.name);
        switch(playerName.GetComponent<PlayerJoin>().playerNumber)
        {
            case 1: 
                gameScore.playerScore1 += pointsToAdd;
                break;
            case 2:
                gameScore.playerScore2 += pointsToAdd;
                break;
            case 3:
                gameScore.playerScore3 += pointsToAdd;
                break;
            case 4:
                gameScore.playerScore4 += pointsToAdd;
                break;
            default:
                print("Player number not found");
                break;
        }
    }
}
