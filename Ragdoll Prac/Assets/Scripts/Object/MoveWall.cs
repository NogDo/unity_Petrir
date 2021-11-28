using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveWall : MonoBehaviour
{
    private void Start()
    {

    }

    public void CheckLeverState()
    {
        Vector3 position = transform.position;
        position.y += transform.localScale.y;

        transform.DOMove(position, 5.0f);
    }
}
