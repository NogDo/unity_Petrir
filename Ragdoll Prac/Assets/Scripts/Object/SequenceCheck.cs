using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceCheck : MonoBehaviour
{
    public SequenceAerial sequenceAerial;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player_Foot"))
        {
            sequenceAerial.CheckSequence(gameObject);
        }
    }
}
