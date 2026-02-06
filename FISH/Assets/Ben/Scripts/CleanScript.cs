using UnityEngine;
using UnityEngine.InputSystem;

public class CleanScript : MonoBehaviour
{
   public float mashDelay = 2f;
   

    float mash;
    bool pressed;
    bool started;

    [SerializeField] private Animator anim;

    public GameObject parent;

    public PlayerInput playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mash = mashDelay;
    }

    // Update is called once per frame
    void Update()
    {
        var startCleanAction = playerInput.actions["Interact"];
        var cleanAction = playerInput.actions["Clean"];

        if (startCleanAction != null && startCleanAction.WasPerformedThisFrame())
        {
            anim.SetBool("isStartCleaning", true);
            started = true;
        }
        if (started)
        {
            mash -= Time.deltaTime;

            if (cleanAction != null && cleanAction.WasPerformedThisFrame() && !pressed)
            {
                anim.SetBool("isStartCleaning", false);
                anim.SetBool("isCleaning", true);
                Debug.Log("Pressed");
                pressed = true;
                mash = mashDelay;
            }
            else if (cleanAction != null && !cleanAction.WasPerformedThisFrame())
            {
                Debug.Log("Not Pressed");
                pressed = false;
            }

            if (mash <= 0)
            {
                Debug.Log("Womp Womp");
                anim.SetBool("isEndCleaning", true);
                anim.SetBool("isCleaning", false);
                started = false;
            }

        }
    }
   

    public void EndClean()
    {
        anim.SetBool("isEndCleaning", false);
    }
}
