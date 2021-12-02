using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    public PlayerController playerController;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger 작동확인 : " + other.gameObject);
        if (other.gameObject.CompareTag("Ground"))
        {
            playerController.isGrounded = true;
            playerController.ResetJumpForce();
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            playerController.isGrounded = true;
            playerController.ResetJumpForce();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision 작동확인 : " + collision.gameObject);
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerController.isGrounded = true;
            playerController.ResetJumpForce();
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            playerController.isGrounded = true;
            playerController.ResetJumpForce();
        }
    }
}
