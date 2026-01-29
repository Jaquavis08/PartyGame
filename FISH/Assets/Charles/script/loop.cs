using Unity.VisualScripting;
using UnityEngine;

public class loop : MonoBehaviour
{
    public GameObject borderTop;
    public GameObject borderBottom;
    public GameObject borderLeft;
    public GameObject borderRight;
    private GameObject player;
    public Rigidbody2D rb2d;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void OnTriggerCollider2D(Collider2D other)  
    {
        if (other.CompareTag("borderTop"))
        {
           player.transform.position = new Vector3(player.transform.position.x, borderBottom.transform.position.y + 1f, player.transform.position.z);
        }
        if (other.CompareTag("borderBottom"))
        {
            player.transform.position = new Vector3(player.transform.position.x, borderTop.transform.position.y - 1f, player.transform.position.z);
        }
        if (other.CompareTag("borderLeft"))
        {
            player.transform.position = new Vector3(borderRight.transform.position.x - 1f, player.transform.position.y, player.transform.position.z);
        }
        if (other.CompareTag("borderRight"))
        {
            player.transform.position = new Vector3(borderLeft.transform.position.x + 1f, player.transform.position.y, player.transform.position.z);
        }
    }

}
