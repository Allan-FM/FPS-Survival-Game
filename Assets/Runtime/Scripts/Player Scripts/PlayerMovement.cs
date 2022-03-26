using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private float jumpForce = 10f;
    private float gravity = 20f;
    private float verticalVelocity; 
    private CharacterController characterController;
    private Vector3 moveDirection;
  
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        MoveThePlayer();
    }
    private void MoveThePlayer()
    {
        moveDirection = new Vector3(Input.GetAxis(Axis.Horizontal), 0f, Input.GetAxis(Axis.Vertical));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        characterController.Move(moveDirection);
    }
    private void ApplyGravity()
    {
        if(characterController.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            PlayerJump();
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        moveDirection.y = verticalVelocity * Time.deltaTime;
    }
    private void PlayerJump()
    {
        if(characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }
    }

}
