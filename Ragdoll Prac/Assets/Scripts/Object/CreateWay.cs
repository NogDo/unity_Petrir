using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWay : MonoBehaviour
{
    public GameObject[] objTriggerFloor;

    public int nIndexCount;
    public bool isCreate;

    private void Start()
    {
        nIndexCount = 0;
        isCreate = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCreate)
        {
            if (other.gameObject.CompareTag("Player_Foot"))
            {
                CreateTriggerFloor();
                isCreate = true;
            }
        }
    }

    public void CreateTriggerFloor()
    {
        for(int i = 0; i < objTriggerFloor.Length; i++)
        {
            objTriggerFloor[i].SetActive(true);
        }
    }
}
