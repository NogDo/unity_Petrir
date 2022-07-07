using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSequenceButton : MonoBehaviour
{
    public ColorSequence colorSequence;

    public bool isChecked;

    private void Start()
    {
        isChecked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_Foot") && !isChecked)
        {
            colorSequence.CheckSequence(transform.parent.gameObject);
        }
    }

    public void ResetChecked()
    {
        isChecked = false;
    }

    public void Checked()
    {
        isChecked = true;
    }
}
