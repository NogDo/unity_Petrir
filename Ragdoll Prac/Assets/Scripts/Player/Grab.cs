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
            Debug.Log("마우스 다운");
            if (isLeftorRight == 0)
            {
                Debug.Log("마우스 왼쪽");
                animator.SetBool("isLeftHandUp", true);
                isCanGrab = true;
            }
            else if (isLeftorRight == 1)
            {
                Debug.Log("마우스 오른쪽");
                animator.SetBool("isRightHandUp", true);
                isCanGrab = true;
            }

            //if(objGrabble != null)
            //{
            //    Debug.Log("물체 생성 확인");
            //    FixedJoint fj = objGrabble.AddComponent<FixedJoint>();
            //    fj.connectedBody = rb;
            //    fj.breakForce = 9000;
            //}
        }
        else if (Input.GetMouseButtonUp(isLeftorRight))
        {
            Debug.Log("마우스 업");
            if (isLeftorRight == 0)
            {
                animator.SetBool("isLeftHandUp", false);
                isCanGrab = false;
            }
            else if (isLeftorRight == 1)
            {
                animator.SetBool("isRightHandUp", false);
                isCanGrab = false;
            }

            //if(objGrabble != null)
            //{
            //    Destroy(objGrabble.GetComponent<FixedJoint>());
            //}

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
