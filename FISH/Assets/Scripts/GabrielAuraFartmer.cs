using UnityEngine;
using UnityEngine.InputSystem;
public class GabrielAuraFartmer : MonoBehaviour
{
    public PlayerInputManager managerScript;
    void Start()
    {
        for(int i = 0; i <InputSystem.devices.Count; i++)
        {
            var device = InputSystem.devices[i];
            if(device.displayName == "Keyboard" ||  device.displayName == "Xbox Controller")
            {
                var input = managerScript.JoinPlayer(pairWithDevice: device);
                Debug.Log("Player " + (i + 1) + " is using a keyboard.");
            }

        }
    }
}
