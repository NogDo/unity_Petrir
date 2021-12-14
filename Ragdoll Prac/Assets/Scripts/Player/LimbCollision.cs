using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    public PlayerController playerController;

    private void Update()
    {
        CheckGround();
    }

    public void CheckGround()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * 0.15f, Color.red);

        if(Physics.Raycast(transform.position, Vector3.down, out hit, 0.15f))
        {
            if (hit.transform.CompareTag("Ground"))
            {
                playerController.isGrounded = true;
                playerController.ResetJumpForce();
            }
            else if (hit.transform.CompareTag("Wall"))
            {
                playerController.isGrounded = true;
                playerController.ResetJumpForce();
            }
            else if (hit.transform.CompareTag("Item"))
            {
                playerController.isGrounded = true;
                playerController.ResetJumpForce();
            }
            else if (hit.transform.CompareTag("Static"))
            {
                playerController.isGrounded = true;
                playerController.ResetJumpForce();
            }
        }
    }
}
