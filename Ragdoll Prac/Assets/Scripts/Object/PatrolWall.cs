using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWall : MonoBehaviour
{
    public GameObject collision_LeftFoot;
    public GameObject collision_RightFoot;
    public GameObject objPlayer;
    public GameObject objPlayerParent;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == collision_LeftFoot)
        {
            objPlayer.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == collision_LeftFoot)
        {
            objPlayer.transform.SetParent(objPlayerParent.transform);
        }
    }
}
