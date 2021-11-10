using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassWall : MonoBehaviour
{
    public BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("작동 확인");
                PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
                if (playerController.isRunning)
                {
                    boxCollider.isTrigger = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            boxCollider.isTrigger = false;
        }
    }
}
