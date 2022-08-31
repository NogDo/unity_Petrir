using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayChestSound : MonoBehaviour
{
    public AudioSource audioSource_ChestSound;
    public HingeJoint hingeJoint_;

    private bool isOpen;

    void Start()
    {
        isOpen = false;
    }

    void Update()
    {
        if(hingeJoint_.angle <= -10 && !isOpen)
        {
            Debug.Log("상자 오픈 사운드 확인");
            audioSource_ChestSound.Play();
            isOpen = true;
        }
        else if(hingeJoint_.angle > -10)
        {
            isOpen = false;
        }
    }
}
