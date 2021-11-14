using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWall : MonoBehaviour
{
    public Animator animator;
    public GameObject objPlayer;

    void Start()
    {
        animator.SetTrigger("WallMove");
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger Enter : " + other.gameObject);
        //if (objPlayer.transform.parent == null)
        //{
        //    objPlayer.transform.SetParent(transform);
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (objPlayer.transform.parent == null)
        {
            Debug.Log("Trigger Stay : " + other.gameObject);
            objPlayer.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit : " + other.gameObject);
        if(objPlayer.transform.parent != null)
        {
            objPlayer.transform.parent = null;
        }
    }
}
