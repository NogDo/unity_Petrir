using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Ingredient
{
    None,
    Biscuit,
    Marshmallow,
    Chocolate,
    Strawberry,
    Strawberry_Cut,
    Bread,
    Pastry_Bag,
    Blueberry,
    ShineMuskat,
    Crust
}

public class ObjectManager : MonoBehaviour
{
    private Vector3 vector_StartPosition;
    private Quaternion quaternion_StartRoatation;

    public Sprite sprite_ObjectImage;
    public Ingredient ingredient;

    void Start()
    {
        vector_StartPosition = transform.position;
        quaternion_StartRoatation = transform.rotation;
    }

    void Update()
    {
        if (transform.position.y <= -20.0f || transform.position.y >= 100.0f)
        {
            while(gameObject.GetComponent<FixedJoint>() != null)
            {
                Destroy(gameObject.GetComponent<FixedJoint>());
            }

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            transform.position = vector_StartPosition;
            transform.rotation = quaternion_StartRoatation;

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
