using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    public Transform transform_TargetLimb;
    public bool mirror;
    ConfigurableJoint configurableJoint;

    private Quaternion startingRotation;
    void Start()
    {
        startingRotation = transform.localRotation;
        configurableJoint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        if (!mirror)
        {
            configurableJoint.SetTargetRotationLocal(transform_TargetLimb.localRotation, startingRotation);
        }
        else
        {
            configurableJoint.SetTargetRotation(Quaternion.Inverse(transform_TargetLimb.localRotation), startingRotation);
        }
    }
}
