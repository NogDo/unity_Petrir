using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public HingeJoint joint_Lever;
    public SequenceAerial sequenceAerial;

    public bool isStartSequence;

    private void Start()
    {
        joint_Lever = GetComponent<HingeJoint>();
        isStartSequence = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (joint_Lever.angle <= -30.0f && !isStartSequence)
        {
            sequenceAerial.ShowSequence();
            isStartSequence = true;
        }
        
    }
}
