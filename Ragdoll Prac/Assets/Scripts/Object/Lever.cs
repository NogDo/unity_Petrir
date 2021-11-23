using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public HingeJoint joint_Lever;
    public MoveWall moveWall;

    public bool isMove = false;

    private void Start()
    {
        joint_Lever = GetComponent<HingeJoint>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (joint_Lever.angle >= 45.0f)
        {
            if (!isMove)
            {
                moveWall.CheckLeverState();
                isMove = true;
            }
        }
        else
        {
            isMove = false;
        }
    }
}
