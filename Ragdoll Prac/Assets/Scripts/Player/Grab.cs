using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Animator animator;
    public GameObject objGrabble;
    public Rigidbody rb;
    public FixedJoint fixedJoint;

    public int isLeftorRight;
    public bool alreadyGrabbing = false;
    public bool isCanGrab = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("아이템 잡기");
            objGrabble = other.gameObject;
            Grabble();
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("벽 잡기");
            objGrabble = other.gameObject;
            Grabble();
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("바닥 잡기");
            objGrabble = other.gameObject;
            Grabble();
        }

        if (other.gameObject.CompareTag("Static"))
        {
            Debug.Log("정지 물체 잡기");
            objGrabble = other.gameObject;
            Grabble();
        }

        if (other.gameObject.CompareTag("Lever"))
        {
            Debug.Log("레버 잡기");
            objGrabble = other.gameObject;
            Grabble();
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    objGrabble = null;
    //}

    public void Grabble()
    {
        if (isCanGrab)
        {
            Debug.Log("물체 생성 확인");
            fixedJoint = objGrabble.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = rb;
            fixedJoint.breakForce = 9000;
            isCanGrab = false;
        }
    }

    public void RemoveJoint()
    {
        Destroy(fixedJoint);
        objGrabble = null;
    }
}
