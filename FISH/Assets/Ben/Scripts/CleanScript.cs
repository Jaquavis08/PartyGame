using UnityEngine;
using UnityEngine.InputSystem;

public class CleanScript : MonoBehaviour
{
    bool pressed;
    bool started;
   

    [SerializeField] private Animator anim;

    public GameObject parent;
    public GameObject cleanPoint;
    public float radius;
    public PlayerInput playerInput;
    public bool ExecuteGizmos;

    // Update is called once per frame
    void Update()
    {

        if(ExecuteGizmos)
        {
            OnDrawGizmos();
        }
        var startCleanAction = playerInput.actions["Interact"];
        var cleanAction = playerInput.actions["Clean"];
        var TDmovement = GetComponentInParent<TDMovement>();

        if (startCleanAction != null && startCleanAction.WasPerformedThisFrame())
        {
            anim.SetBool("isStartCleaning", true);
            started = true;
            TDmovement.changeToLessSpeed();
            ExecuteGizmos = true;
        }
        if (started)
        {

            if (cleanAction != null && cleanAction.WasPerformedThisFrame() && !pressed)
            {
                Debug.Log("Pressed");
                pressed = true;
                
            }
            else if (cleanAction != null && !cleanAction.WasPerformedThisFrame())
            {
                pressed = false;
            }

            if (anim.GetBool("isCleaning") && startCleanAction.WasPerformedThisFrame())
            {
                Debug.Log("Womp Womp");
                anim.SetBool("isStartCleaning", false);
                anim.SetBool("isEndCleaning", true);
                anim.SetBool("isCleaning", false);
                TDmovement.changeToOriginalSpeed();
                ExecuteGizmos = false;
                started = false; 
            }

        }
    }

    
    public void StartClean()
    {
        
        anim.SetBool("isStartCleaning", false);
        anim.SetBool("isCleaning", true);
    }

    public void EndClean()
    {
        anim.SetBool("isEndCleaning", false);

    }

    public void DisableClean()
    {
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(cleanPoint.transform.position, radius);

    }
}
