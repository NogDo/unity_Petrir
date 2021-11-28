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
}
