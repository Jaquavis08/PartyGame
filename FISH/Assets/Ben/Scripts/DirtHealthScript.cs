using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DirtHealthScript : MonoBehaviour
{
    public float health;
    public float currentHealth;
    
    public GameObject dirt;
   
    public GameObject particles;

    public GameObject dirtyFish;

    public GameObject Player;

    public bool isDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    { 
        currentHealth = health;
        particles = gameObject.GetComponentInChildren<ParticleSystem>().gameObject;

    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth > health)
        {

            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            currentHealth = health;

        }
        if (health <= 0)
        {




            
            StartCoroutine("Wait");


        }

    }
    private IEnumerator Wait()
    {
        gameObject.GetComponentInChildren<ParticleSystem>().Play();
        particles.transform.SetParent(dirtyFish.transform);
        gameObject.GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        if (!gameObject.GetComponentInChildren<ParticleSystem>().isPlaying)
        {
            Destroy(dirt);
            
        }

    }


    
}
