using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //public GameObject objPlayer;
    public PlayerManager playerManager;
    public Vector3 vector3_CheckPoint;

    public GameObject objCheckPoint;
    public Material material_Pink;
    public Material material_Green;
    public AudioSource audioSource_CheckPoint;

    [Header("예외로 다뤄야할 오브젝트들")]
    public GameObject objCandy;

    private bool isChecked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isChecked)
        {
            if (other.gameObject.CompareTag("Player_Foot"))
            {
                Debug.Log("체크포인트 활성화!");
                Vector3 check = transform.position;
                vector3_CheckPoint = new Vector3(check.x, check.y + 5.0f, check.z);
                playerManager.CheckPoint(vector3_CheckPoint);
                audioSource_CheckPoint.Play();

                objCheckPoint.GetComponent<MeshRenderer>().material.color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f);
                StartCoroutine(CheckPoint_To_ChangeColor());

                if(objCandy != null)
                {
                    objCandy.SetActive(true);
                }
            }
        }
    }
    
    IEnumerator CheckPoint_To_ChangeColor()
    {
        yield return new WaitForSeconds(1.0f);
        objCheckPoint.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
