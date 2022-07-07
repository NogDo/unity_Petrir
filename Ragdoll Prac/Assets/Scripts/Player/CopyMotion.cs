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
            //configurableJoint.targetRotation = transform_TargetLimb.rotation;
            //configurableJoint.SetTargetRotation(transform_TargetLimb.localRotation, startingRotation);
            configurableJoint.SetTargetRotationLocal(transform_TargetLimb.localRotation, startingRotation);
        }
        else
        {
            //configurableJoint.targetRotation = Quaternion.Inverse(transform_TargetLimb.rotation);
            configurableJoint.SetTargetRotation(Quaternion.Inverse(transform_TargetLimb.localRotation), startingRotation);
        }
    }
}
