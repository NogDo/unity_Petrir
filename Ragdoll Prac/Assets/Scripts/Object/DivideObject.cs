using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideObject : MonoBehaviour
{
    public GameObject objKnife;

    public bool isKnifeEnter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == objKnife)
        {
            Debug.Log("칼날 닿은거 확인");
            isKnifeEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == objKnife)
        {
            Debug.Log("칼날 다시 빠짐 확인");
            isKnifeEnter = false;
        }
    }

    public bool GetIsKnifeEnter()
    {
        return isKnifeEnter;
    }
}
