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

    }
}
