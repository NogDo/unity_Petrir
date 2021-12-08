using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Vector3 vector_StartPosition;
   

    private void Start()
    {
        vector_StartPosition = transform.position;
    }

    void Update()
    {
        if(transform.localPosition.z <= -20.0f)
        {
            transform.position = vector_StartPosition;
        }
    }
}
