using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Animator animator;
    public GameObject objGrabble;
    public Rigidbody rb;
    public FixedJoint fixedJoint;

    public TutorialManager tutorialManager;

    public int isLeftorRight;

    public bool alreadyGrabbing = false;
    public bool isCanGrab = false;
    public bool isCanGrabBehavior;

    private bool isEndGrabTutorial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isEndGrabTutorial = false;
    }

    void Update()
    {
        if (isCanGrabBehavior)
        {
            if (Input.GetMouseButtonDown(isLeftorRight))
            {
                if (isLeftorRight == 0)
                {
                    animator.SetBool("LeftGrab", true);
                    isCanGrab = true;
                }
                else if (isLeftorRight == 1)
                {
                    animator.SetBool("RightGrab", true);
                    isCanGrab = true;
                }
            }
            else if (Input.GetMouseButtonUp(isLeftorRight))
            {
                if (isLeftorRight == 0)
                {
                    animator.SetBool("LeftGrab", false);
                    isCanGrab = false;
                }
                else if (isLeftorRight == 1)
                {
                    animator.SetBool("RightGrab", false);
                    isCanGrab = false;
                }

                if (objGrabble != null)
                {
                    RemoveJoint();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("아이템 잡기");
            objGrabble = other.gameObject;
            Grabble(true);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("벽 잡기");
            objGrabble = other.gameObject;
            Grabble(false);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("바닥 잡기");
            objGrabble = other.gameObject;
            Grabble(false);
        }

        if (other.gameObject.CompareTag("Static"))
        {
            Debug.Log("정지 물체 잡기");
            objGrabble = other.gameObject;
            Grabble(false);
        }

        if (other.gameObject.CompareTag("Lever"))
        {
            Debug.Log("레버 잡기");
            objGrabble = other.gameObject;
            Grabble(false);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    objGrabble = null;
    //}

    public void Grabble(bool isItem)
    {
        if (isCanGrab)
        {
            Debug.Log("물체 생성 확인");
            fixedJoint = objGrabble.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = rb;
            fixedJoint.breakForce = 9000;
            if (tutorialManager.IsStartGrabTutorial() && !isEndGrabTutorial && isItem && (isLeftorRight == 0))
            {
                Debug.Log("그랩 튜토리얼 완료 확인");
                tutorialManager.EndGrabTutorial();
                isEndGrabTutorial = true;
            }
            isCanGrab = false;
        }
    }

    public void RemoveJoint()
    {
        Destroy(fixedJoint);
        objGrabble = null;
    }

    public void UnAbleGrabBehavior()
    {
        isCanGrabBehavior = false;
    }

    public void AbleGrabBehavior()
    {
        isCanGrabBehavior = true;
    }
}
