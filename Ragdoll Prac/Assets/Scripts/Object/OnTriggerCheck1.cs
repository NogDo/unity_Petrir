using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerCheck1 : MonoBehaviour
{
    public PatrolPath patrolPath;

    public bool isStartPath;

    private void Start()
    {
        isStartPath = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_Foot") && !isStartPath)
        {
            patrolPath.StartPathMove();
            isStartPath = true;
        }
    }
}
