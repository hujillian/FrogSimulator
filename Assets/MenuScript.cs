using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI scoreLabel;
    public GameObject mainCam;
    public Canvas menuUI;

    private bool isMenuPressedDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Bugs eaten: " + mainCam.GetComponent<AimSelector>().score;

        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), InputHelpers.Button.MenuButton, out bool isPressed);
        if (isPressed)
        {
            if (!isMenuPressedDown)
            {
                menuUI.enabled = !menuUI.enabled;
            }

            isMenuPressedDown = true;
        }
        else
        {
            isMenuPressedDown = false;
        }
    }
}
