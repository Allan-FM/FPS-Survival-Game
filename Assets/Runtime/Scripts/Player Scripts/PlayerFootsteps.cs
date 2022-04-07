using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerFootsteps : MonoBehaviour
{

    [Header("Audio")]
    [Space]
    private AudioSource footstepsSound;
    [SerializeField] private AudioClip[] footstepClip;

    [Header("Volume")]
    [Space]
    [HideInInspector] private float minVolume;
    [HideInInspector] private float maxVolume;

    private CharacterController characterController;
    private float accumulateDistance;
    [HideInInspector] private float stepDistance;
    private void Awake()
    {
       footstepsSound = GetComponent<AudioSource>();
       characterController = GetComponent<CharacterController>(); 
    }
    private void Update()
    {
        CheckToPlayFootstepSound();
    }
    private void CheckToPlayFootstepSound()
    {
        if(!characterController.isGrounded)
        {
            return;
        }
    }

}
