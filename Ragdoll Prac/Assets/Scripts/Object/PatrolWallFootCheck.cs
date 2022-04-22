using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWallFootCheck : MonoBehaviour
{
    public PatrolWall patrolWall;

    public GameObject collision_LeftFoot;
    public GameObject collision_RightFoot;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == collision_LeftFoot)
        {
            patrolWall.SetPlayerParent_To_PatrolWall();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collision_LeftFoot)
        {
            patrolWall.SetPlayerParent_To_Character();
        }
    }
}
