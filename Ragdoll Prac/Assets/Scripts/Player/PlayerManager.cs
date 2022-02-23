using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Vector3 vector_StartPosition;

    [Header("플레이어 텔레포트 위치")]
    public Vector3 vector_TutorialStartPosition;

    [Header("플레이어 캐릭터 최상위 부모")]
    public GameObject objCharacter;

    private void Start()
    {
        vector_StartPosition = transform.position;
    }

    void Update()
    {
        if(transform.localPosition.z <= -20.0f)
        {
            transform.position = vector_StartPosition;
        }
    }

    public void MoveToTutorialStage()
    {
        objCharacter.transform.position = vector_TutorialStartPosition;
        transform.position = vector_TutorialStartPosition;
        vector_StartPosition = vector_TutorialStartPosition;
    }
}
