﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Vector3 vector_StartPosition;
    private Quaternion quaternion_StartRoatation;

    public Sprite sprite_ObjectImage;

    void Start()
    {
        vector_StartPosition = transform.position;
        quaternion_StartRoatation = transform.rotation;
    }

    void Update()
    {
        if (transform.position.y <= -20.0f)
        {
            transform.position = vector_StartPosition;
            transform.rotation = quaternion_StartRoatation;
        }
    }
}