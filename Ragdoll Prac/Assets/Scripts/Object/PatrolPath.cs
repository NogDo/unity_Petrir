using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PatrolPath : MonoBehaviour
{
    public GameObject[] objPath;
    public Vector3[] wayPoints;

    public void StartPathMove()
    {
        wayPoints = new Vector3[objPath.Length];
        for(int i = 0; i < objPath.Length; i++)
        {
            wayPoints[i].Set(objPath[i].transform.position.x, objPath[i].transform.position.y, objPath[i].transform.position.z);
        }

        transform.DOPath(wayPoints, 20.0f, PathType.Linear).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }
}
