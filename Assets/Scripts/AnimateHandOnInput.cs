using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // to use hand animation according controller input

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // to check if there is any input
    // Update is called once per frame
    void Update()
    {
        //checking through the value how much button is pressed
        float triggerValue = pinchAnimationAction.action.ReadValue<float>(); //input of the trigger button
        handAnimator.SetFloat("Trigger", triggerValue);//to show pinch animation

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);//to show grip animation

    }
}
