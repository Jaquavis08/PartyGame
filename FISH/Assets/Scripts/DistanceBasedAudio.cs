using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
   public AudioSource audioSource;
    public Transform player;
    public float maxDistance = 5f;
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        float volume = Mathf.Clamp01(1 - (distance / maxDistance));

        audioSource.volume = volume;
    }
}
