using UnityEngine;

[CreateAssetMenu(fileName = "GameScore", menuName = "Scriptable Objects/GameScore")]
public class GameScore : ScriptableObject
{
    public int playerScore1;
    public int playerScore2;
    public int playerScore3;
    public int playerScore4;
    public int highestScore;
}
