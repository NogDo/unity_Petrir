using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceAerial : MonoBehaviour
{
    public GameObject[] obj_SequenceAerials;
    public GameObject[] obj_AllAreirals;
    public GameObject[] obj_Static2;

    public Material mat_MoveBasic;
    public Material mat_MoveSequence;

    public int nMaterialIndex;
    public int nSequenceIndex;
    public int nSequenceMaxCount;

    public bool isEndSequence;
    public bool isStartSequence;

    private void Start()
    {
        nMaterialIndex = 0;
        nSequenceIndex = 0;
        isEndSequence = false;
        isStartSequence = false;
    }

    public void ShowSequence()
    {
        StartCoroutine(SetMaterialBasic());
    }

    public void CheckSequence(GameObject obj_Aerials)
    {
        if (nSequenceIndex < nSequenceMaxCount)
        {
            if (obj_SequenceAerials[nSequenceIndex] == obj_Aerials)
            {
                nSequenceIndex++;
                if(nSequenceIndex < nSequenceMaxCount)
                {
                    for (int i = 0; i < obj_SequenceAerials.Length; i++)
                    {
                        obj_SequenceAerials[i].GetComponent<BoxCollider>().isTrigger = true;
                    }

                    for (int i = nSequenceIndex - 1; i <= nSequenceIndex; i++)
                    {
                        obj_SequenceAerials[i].GetComponent<BoxCollider>().isTrigger = false;
                    }
                }
                else
                {
                    EndSequence();
                }
            }
        }
    }

    public void EndSequence()
    {
        for (int i = 0; i < obj_AllAreirals.Length; i++)
        {
            obj_AllAreirals[i].GetComponent<BoxCollider>().isTrigger = false;
        }

        for(int i = 0; i < obj_Static2.Length; i++)
        {
            obj_Static2[i].GetComponent<BoxCollider>().isTrigger = false;
        }

        isEndSequence = true;
    }

    public void ResetSequence()
    {
        if (!isStartSequence)
        {
            return;
        }

        if (isEndSequence)
        {
            return;
        }

        nSequenceIndex = 0;
        for (int i = 0; i < obj_SequenceAerials.Length; i++)
        {
            obj_SequenceAerials[i].GetComponent<BoxCollider>().isTrigger = true;
        }

        obj_SequenceAerials[0].GetComponent<BoxCollider>().isTrigger = false;
    }

    IEnumerator SetMaterialBasic()
    {
        //obj_SequenceAerials[nMaterialIndex].transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = mat_MoveSequence;
        obj_SequenceAerials[nMaterialIndex].transform.GetChild(0).GetComponent<MeshRenderer>().material = mat_MoveSequence;
        yield return new WaitForSeconds(0.8f);
        //obj_SequenceAerials[nMaterialIndex].transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = mat_MoveBasic;
        obj_SequenceAerials[nMaterialIndex].transform.GetChild(0).GetComponent<MeshRenderer>().material = mat_MoveBasic;
        nMaterialIndex++;
        if (nMaterialIndex < nSequenceMaxCount)
        {
            StartCoroutine(SetMaterialBasic());
        }
        else
        {
            obj_SequenceAerials[0].GetComponent<BoxCollider>().isTrigger = false;
            isStartSequence = true;
        }
    }
}
