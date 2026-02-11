using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class DirtHealthScript : MonoBehaviour
{
    public float health;
    public float currentHealth;
    
    public GameObject dirt;
   
    public ParticleSystem particles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    { 
        currentHealth = health;
        particles = gameObject.GetComponentInChildren<ParticleSystem>();
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
            StartCoroutine("Death");
        }
    }
    private IEnumerator Death()
    {
        particles.Play();
        particles.transform.parent = null;
        dirt.GetComponent<Image>().sprite = null;
        yield return new WaitForSeconds(2f);
        particles.Stop();
        Destroy(particles);
    }
    
}

