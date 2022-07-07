using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float fRotationSpeed = 1;
    public float fStomachOffset;

    public Transform transform_Root;
    public ConfigurableJoint hipJoint, stomachJoint;

    private float mouseX, mouseY;
    private Quaternion lastHipRotation, lastStomachRotation;

    public bool isScreenRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        if (!isScreenRotation)
        {
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                OnlyCamControl();
            }
            else
            {
                CamControl();
            }
        }
        else
        {
            hipJoint.targetRotation = lastHipRotation;
            stomachJoint.targetRotation = lastStomachRotation;
        }
    }

    public void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * fRotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * fRotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        Quaternion rootRatation = Quaternion.Euler(mouseY, mouseX, 0);

        transform_Root.rotation = rootRatation;
        hipJoint.targetRotation = Quaternion.Euler(mouseX, 0, 0);
        stomachJoint.targetRotation = Quaternion.Euler(0, 0, mouseY + fStomachOffset);
        lastHipRotation = hipJoint.targetRotation;
        lastStomachRotation = stomachJoint.targetRotation;
    }

    public void OnlyCamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * fRotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * fRotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        Quaternion rootRatation = Quaternion.Euler(mouseY, mouseX, 0);

        transform_Root.rotation = rootRatation;
        hipJoint.targetRotation = lastHipRotation;
        stomachJoint.targetRotation = lastStomachRotation;
    }

    public void StopScreenRotation()
    {
        isScreenRotation = true;
    }

    public void StartScreenRotation()
    {
        isScreenRotation = false;
    }
}
