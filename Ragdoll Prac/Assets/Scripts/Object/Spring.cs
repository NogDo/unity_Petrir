using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public PlayerController playerController;

    public AudioSource audio_JellyJump;

    public Animator animator;

    public float fJumpPower;
    public int nJumpCount;

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
            animator.SetTrigger("Step");
            playerController.isGrounded = true;
            playerController.AddJumpForce(fJumpPower, nJumpCount);
            audio_JellyJump.Play();
        }
    }
}
