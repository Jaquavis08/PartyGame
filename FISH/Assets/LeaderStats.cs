using System.Collections.Generic;
using UnityEngine;

public class LeaderStats : MonoBehaviour
{

    public List<Data> stats = new List<Data>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (player == null) continue;

            // Only add if we don't already have an entry for this player
            if (!stats.Exists(s => s.player == player))
            {
                stats.Add(new Data { player = player, points = 0});
            }
        }

        // Optional: clean up entries whose GameObject was destroyed
        stats.RemoveAll(s => s.player == null);
    }
}
