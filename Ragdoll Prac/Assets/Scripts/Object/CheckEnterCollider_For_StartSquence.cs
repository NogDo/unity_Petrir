using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnterCollider_For_StartSquence : MonoBehaviour
{
    public SequenceAerial sequenceAerial;

    public bool isStartSquence;

    private void Start()
    {
        isStartSquence = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isStartSquence)
        {
            if (other.gameObject.CompareTag("Player_Foot"))
            {
                sequenceAerial.ShowSequence();
                isStartSquence = true;
            }
        }
    }
}
