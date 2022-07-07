using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinctionAerial : MonoBehaviour
{
    public float fExtinctionTime;
    public float fRewindTime;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player_Foot"))
        {
            Debug.Log("소멸발판 실행");
            StartCoroutine(Extinction());
        }
    }

    IEnumerator Extinction()
    {
        yield return new WaitForSeconds(fExtinctionTime);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<BoxCollider>().isTrigger = true;
        StartCoroutine(Rewind());
    }

    IEnumerator Rewind()
    {
        yield return new WaitForSeconds(fRewindTime);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<BoxCollider>().isTrigger = false;
    }
}
