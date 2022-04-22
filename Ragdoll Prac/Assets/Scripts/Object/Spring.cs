﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public PlayerController playerController;

    public AudioSource audio_JellyJump;

    public float fJumpPower;

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Player_Foot"))
        //{
        //    playerController.isGrounded = true;
        //    playerController.AddJumpForce(fJumpPower);
        //    audio_JellyJump.Play();
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player_Foot"))
        {
            playerController.isGrounded = true;
            playerController.AddJumpForce(fJumpPower);
            audio_JellyJump.Play();
        }
    }
}
