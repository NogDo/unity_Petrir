using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public GameObject objPlayer;
    public PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player_Foot"))
        {
            playerController.isGrounded = true;
            playerController.AddJumpForce();
        }
    }
}
