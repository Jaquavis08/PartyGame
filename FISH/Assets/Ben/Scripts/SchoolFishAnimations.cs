using UnityEngine;

public class SchoolFishAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator parentAnimator;

    // Update is called once per frame
    void Update()
    {
       if (parentAnimator.GetBool("isRunning") == true)
       {
           animator.SetBool("isRunning", true);
       }
       else
       {
           animator.SetBool("isRunning", false);
       }          
    }
}
