using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerRoot;
    [SerializeField] private Transform lookRoot;
    [SerializeField] private bool invert;
    [SerializeField] private bool canUnlock = true;
    [SerializeField] private float sensivity = 5f;
    [SerializeField] private int smoothSteps = 10;
    [SerializeField] private float smoothWeigth = 0.4f;
    [SerializeField] private float rollAngle = 10f;
    [SerializeField] private float rollSpeed = 3f;
    [SerializeField] private Vector2 defaultLookLimits = new Vector2(-70f, 80f);
    private Vector2 lookAngles;
    private Vector2 currentMouseLook;
    private Vector2 smoothMove;
    private float currentRollAngle;
    private int lastLookFrame;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        LookAndUnlookCursor();
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            LookAround();
        }
    }
    private void LookAndUnlookCursor()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
    private void LookAround()
    {
        currentMouseLook = new Vector2(Input.GetAxis(MouseAxis.MouseY), 
                                        Input.GetAxis(MouseAxis.MouseX));

        lookAngles.x += currentMouseLook.x * sensivity * (invert ? 1f : -1f);
        lookAngles.y += currentMouseLook.y * sensivity;
        lookAngles.x = Mathf.Clamp(lookAngles.x, defaultLookLimits.x, defaultLookLimits.y);

        //     currentRollAngle = 
        //     Mathf.Lerp(currentRollAngle, 
        //     Input.GetAxisRaw(MouseAxis.MouseX) * rollAngle, 
        //     rollSpeed * Time.deltaTime);
        
        lookRoot.localRotation = Quaternion.Euler(lookAngles.x, 0f, currentRollAngle);
        playerRoot.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f);
    }

}
