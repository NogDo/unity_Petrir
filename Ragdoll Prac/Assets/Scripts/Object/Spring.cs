using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public PlayerController playerController;

    public float fJumpPower;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player_Foot"))
        {
            playerController.isGrounded = true;
            playerController.AddJumpForce(fJumpPower);
        }
    }
}
