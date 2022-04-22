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
        if(tutorialManager != null)
        {
            if (tutorialManager.IsStartJumpTutorial() && !isOnce && playerController.isJump)
            {
                Debug.Log("이게 문젠가3");
                StartJumpTutorial();
                isOnce = true;
            }
        }
        CheckGround();
    }

    public void CheckGround()
    {
        RaycastHit hit;
        Vector3 down = transform.TransformDirection(Vector3.left);
        Debug.DrawRay(transform.position, down * 0.25f, Color.red);

        // 튜토리얼 가이드에서만 쓰이는 점프 판정 (왼발에만)
        if (isStartJumpTutorial && isLeftorRight == 0)
        {
            if (Physics.Raycast(transform.position, down, out hit, 0.25f))
            {
                if (!playerController.isDelayToJump)
                {
                    if (hit.transform.CompareTag("Ground"))
                    {
                        if (isStartJumpTutorial && !playerController.isGrounded)
                        {
                            tutorialManager.EndJumpTutorial();
                            isStartJumpTutorial = false;
                            Debug.Log("점프 튜토리얼 완료");
                        }
                        InitJumpState();
                    }
                }
            }
        }
        
        // 튜토리얼 가이드 이후에 쓰는 점프판정 (양발)
        if (Physics.Raycast(transform.position, down, out hit, 0.25f) && !isStartJumpTutorial)
        {
            if (!playerController.isDelayToJump)
            {
                if (hit.transform.CompareTag("Ground"))
                {
                    InitJumpState();
                }
                else if (hit.transform.CompareTag("Wall"))
                {
                    InitJumpState();
                }
                else if (hit.transform.CompareTag("Item"))
                {
                    InitJumpState();
                }
                else if (hit.transform.CompareTag("Static"))
                {
                    InitJumpState();
                }
                else if (hit.transform.CompareTag("MoveWall"))
                {
                    InitJumpState();
                }
                else if (hit.transform.CompareTag("Spring"))
                {
                    playerController.isGrounded = false;
                    playerController.isJump = false;
                    playerController.fRunSpeed = 2.0f;
                }
                else 
                {
                    playerController.isGrounded = false;
                }
            }
        }
    }

    public void InitJumpState()
    {
        playerController.isGrounded = true;
        playerController.isJump = false;
        playerController.ResetJumpForce();
        playerController.fRunSpeed = 2.0f;
    }

    public void StartJumpTutorial()
    {
        isStartJumpTutorial = true;
    }
}
