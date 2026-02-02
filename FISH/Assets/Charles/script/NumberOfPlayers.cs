using UnityEngine;

public class NumberOfPlayers : MonoBehaviour
{
    private int numberOfPlayers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<PlayerJoin>().playerNumber = numberOfPlayers;
        if (numberOfPlayers == 0)
        {
            GetComponent<PlayerJoin>().image.SetActive(true);

        }
        if (numberOfPlayers != null && numberOfPlayers != 0)
        {

            GetComponent<PlayerJoin>().image.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
