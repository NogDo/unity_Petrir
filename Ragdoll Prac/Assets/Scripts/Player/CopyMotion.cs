using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    public Transform transform_TargetLimb;
    public bool mirror;
    ConfigurableJoint configurableJoint;

    void Start()
    {
        configurableJoint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        if (!mirror)
        {
            configurableJoint.targetRotation = transform_TargetLimb.rotation;
        }
        else
        {
            configurableJoint.targetRotation = Quaternion.Inverse(transform_TargetLimb.rotation);
        }
    }
}
