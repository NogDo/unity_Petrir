using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject objPlayer;
    public GameObject ojbPlayerHips;
    public Vector3 vector3_CheckPoint;

    public Material material_Pink;
    public Material material_Green;

    private bool isChecked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isChecked)
        {
            if (other.gameObject.CompareTag("Player_Foot"))
            {
                Debug.Log("체크포인트 활성화!");
                Vector3 check = transform.position;
                vector3_CheckPoint = new Vector3(check.x, check.y + 10.0f, check.z);
                isChecked = true;

                GetComponent<MeshRenderer>().material = material_Green;
                StartCoroutine(CheckPoint_To_ChangeColor());
            }
        }
    }

    private void Update()
    {
        if (isChecked)
        {
            if (ojbPlayerHips.transform.position.y <= -40.0f)
            {
                for(int i = 0; i < objPlayer.transform.childCount; i++)
                {
                    objPlayer.transform.GetChild(i).transform.localPosition = Vector3.zero;
                }
                objPlayer.transform.position = vector3_CheckPoint;
            }
        }
    }
    
    IEnumerator CheckPoint_To_ChangeColor()
    {
        yield return new WaitForSeconds(1.0f);
        GetComponent<MeshRenderer>().material = material_Pink;
    }
}
