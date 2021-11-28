using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float fRotationSpeed = 1;
    public float fStomachOffset;

    public Transform transform_Root;
    public ConfigurableJoint hipJoint, stomachJoint;

    float mouseX, mouseY;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        CamControl();
    }
     
    public void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * fRotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * fRotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        Quaternion rootRatation = Quaternion.Euler(mouseY, mouseX, 0);

        transform_Root.rotation = rootRatation;
        hipJoint.targetRotation = Quaternion.Euler(0, -mouseX, 0);
        stomachJoint.targetRotation = Quaternion.Euler(-mouseY + fStomachOffset, 0, 0);
    }
}
