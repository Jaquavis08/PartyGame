using UnityEngine;
using System.Collections.Generic;

public class FihListt : MonoBehaviour
{
    public List<GameObject> FihList;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var list = FihList;
        if (list == null || list.Count == 0)
        {
            return;
        }
        switch (list.Count)
        {
            case 1:
                
                break;
            case 2:
                list[0].SetActive(true);
                list[1].SetActive(true);
                break;
            case 3:
                list[0].SetActive(true);
                list[1].SetActive(true);
                list[2].SetActive(true);
                break;
            case 4:
                list[0].SetActive(true);
                list[1].SetActive(true);
                list[2].SetActive(true);
                list[3].SetActive(true);
                break;
        }
    }
}
