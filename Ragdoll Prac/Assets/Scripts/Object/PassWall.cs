using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWall : MonoBehaviour
{
    public BoxCollider boxCollider;

    public PlayerController playerController;
    public GameObject objPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == objPlayer)
        {
            Debug.Log("PassWall 엔터");
            playerController.EnterPassWall();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objPlayer)
        {
            Debug.Log("PassWall 나감");
            playerController.ExitPassWall();
        }
    }
}
