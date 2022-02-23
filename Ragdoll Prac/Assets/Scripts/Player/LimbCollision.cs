using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    public PlayerController playerController;
    public TutorialManager tutorialManager;

    public int isLeftorRight;

    private bool isStartJumpTutorial;
    private bool isOnce;

    private void Start()
    {
        isStartJumpTutorial = false;
        isOnce = false;
    }

    private void Update()
    {
        CheckGround();
        if (tutorialManager.IsStartJumpTutorial() && !isOnce && playerController.isJump && (isLeftorRight == 0))
        {
            Debug.Log("이게 문젠가3");
            StartJumpTutorial();
            isOnce = true;
        }
    }

    public void CheckGround()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * 0.15f, Color.red);

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.15f))
        {
            if (!playerController.isDelayToJump)
            {
                if (hit.transform.CompareTag("Ground"))
                {
                    if (isStartJumpTutorial && !playerController.isGrounded)
                    {
                        tutorialManager.EndJumpTutorial();
                        isStartJumpTutorial = false;
                        Debug.Log("이게문젠가2" + isStartJumpTutorial);
                    }
                    playerController.isGrounded = true;
                    playerController.isJump = false;
                    playerController.ResetJumpForce();
                    playerController.fRunSpeed = 2.0f;
                }
                else if (hit.transform.CompareTag("Wall"))
                {
                    playerController.isGrounded = true;
                    playerController.isJump = false;
                    playerController.ResetJumpForce();
                    playerController.fRunSpeed = 2.0f;
                }
                else if (hit.transform.CompareTag("Item"))
                {
                    playerController.isGrounded = true;
                    playerController.isJump = false;
                    playerController.ResetJumpForce();
                    playerController.fRunSpeed = 2.0f;
                }
                else if (hit.transform.CompareTag("Static"))
                {
                    playerController.isGrounded = true;
                    playerController.isJump = false;
                    playerController.ResetJumpForce();
                    playerController.fRunSpeed = 2.0f;
                }
                else 
                {
                    playerController.isGrounded = false;
                }
            }
        }
    }

    public void StartJumpTutorial()
    {
        isStartJumpTutorial = true;
    }
}
