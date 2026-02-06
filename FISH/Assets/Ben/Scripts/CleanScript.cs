using JetBrains.Annotations;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class CleanScript : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public GameObject parent;

    public PlayerInput playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        var cleanAction = playerInput.actions["Interact"];

        if (cleanAction != null && cleanAction.WasPerformedThisFrame())
        {
            anim.SetBool("isStartCleaning", true);

        }
    }
    void Clean()
    {
           anim.SetBool("isStartCleaning", false);
           anim.SetBool("isCleaning", true);
    }

    
}
