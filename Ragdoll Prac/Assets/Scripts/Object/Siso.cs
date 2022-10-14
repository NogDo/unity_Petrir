using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siso : MonoBehaviour
{
    public HingeJoint hingeJoint_this;

    public bool isCollision;

    public float fRotationX;
    public float fRotationY;
    public float fRotationZ;
    public float fReturnPower;

    private void Start()
    {
        isCollision = false;
        fReturnPower = 0;
    }

    void Update()
    {
        if(hingeJoint_this.angle != 0)
        {
            if (!isCollision)
            {
                if(hingeJoint_this.angle > 0)
                {
                    fReturnPower = -0.25f;
                }
                else if(hingeJoint_this.angle < 0)
                {
                    fReturnPower = 0.25f;
                }

                transform.rotation = Quaternion.Euler(fRotationX + hingeJoint_this.angle + fReturnPower, fRotationY, fRotationZ);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player_Foot"))
        {
            isCollision = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player_Foot"))
        {
            isCollision = false;
        }
    }
}
