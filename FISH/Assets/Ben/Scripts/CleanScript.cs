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
    public float damage;

    public LayerMask cleanees;

    // Update is called once per frame
    void Update()
    {
        var startCleanAction = playerInput.actions["Interact"];
        var cleanAction = playerInput.actions["Clean"];
        var TDmovement = GetComponentInParent<TDMovement>();

        if (startCleanAction != null && startCleanAction.WasPerformedThisFrame()) //Checks to see if the player pressed the StartClean button(E on Keyboard or Button East on controller)
        {
            anim.SetBool("isStartCleaning", true);
            started = true;
            TDmovement.changeToLessSpeed();
        }
        if (started)
        {
            ExecuteGizmos = true;

            if (cleanAction != null && cleanAction.WasPerformedThisFrame() && !pressed)
            {
                Debug.Log("Pressed");
                pressed = true;
                Clean();

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

    public void Clean()
    {
        Collider2D[] cleanee = Physics2D.OverlapCircleAll(cleanPoint.transform.position, radius, cleanees);

        foreach (Collider2D cleanGameObject in cleanee)
        {
            Debug.Log("Clean");
            cleanGameObject.GetComponent<DirtHealthScript>().health -= damage;
        }
    }

    public void EndClean()
    {
        anim.SetBool("isEndCleaning", false);
    }

    private void OnDrawGizmos()
    {  
            Gizmos.DrawWireSphere(cleanPoint.transform.position, radius);
    }
}
