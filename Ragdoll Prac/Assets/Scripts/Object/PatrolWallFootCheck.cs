using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWallFootCheck : MonoBehaviour
{
    public PatrolWall patrolWall;

    public GameObject collision_LeftFoot;
    public GameObject collision_RightFoot;

    public bool isLeftFootExit;
    public bool isRightFootExit;

    private void Start()
    {
        isLeftFootExit = true;
        isRightFootExit = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == collision_LeftFoot)
        {
            isLeftFootExit = false;
            patrolWall.SetPlayerParent_To_PatrolWall();
        }

        if(other.gameObject == collision_RightFoot)
        {
            isRightFootExit = false;
            patrolWall.SetPlayerParent_To_PatrolWall();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collision_LeftFoot)
        {
            isLeftFootExit = true;
        }

        if(other.gameObject == collision_RightFoot)
        {
            isRightFootExit = true;
        }

        if(isLeftFootExit && isRightFootExit)
        {
            patrolWall.SetPlayerParent_To_Character();
        }
    }
}
