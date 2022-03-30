using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerSprintAndCrouch : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [Header("Speeds")]
    [Space]
    [SerializeField] private float sprintSpeed = 10f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float crouchSpeed = 2f;

    private Transform lookRoot;
    private float standHeigth = 1.6f;
    private float crounchHeigth = 1f;
    private bool isCrouching;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

        lookRoot = transform.GetChild(0);
    }
    private void Update()
    {
        Sprint();
        Crouch();
    }
    private void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
        {
            playerMovement.speed = sprintSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            playerMovement.speed = moveSpeed;
        }
    }
    private void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            //if we are crouching - stand up
            if(isCrouching)
            {
                lookRoot.localPosition = new Vector3(0f,standHeigth, 0f);
                playerMovement.speed = moveSpeed;

                isCrouching = false;
            }
            //if we are not crouching - crouch
            else
            {
                lookRoot.localPosition = new Vector3(0f, crounchHeigth, 0f);
                playerMovement.speed = crouchSpeed;

                isCrouching = true;
            }
        }
    }

}
