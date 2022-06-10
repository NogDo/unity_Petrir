using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWall : MonoBehaviour
{
    public GameObject objPlayer;

    private bool isOnFloor;
    private Vector3 distance;

    private void Update()
    {
        if (isOnFloor)
        {
            objPlayer.transform.position = transform.position - distance;
        }
    }

    public void SetPlayerParent_To_PatrolWall()
    {
        isOnFloor = true;
        distance = transform.position - objPlayer.transform.position;
    }

    public void SetPlayerParent_To_Character()
    {
        isOnFloor = false;
    }
}
