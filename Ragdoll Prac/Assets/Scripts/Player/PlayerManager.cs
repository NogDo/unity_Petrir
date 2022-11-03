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

    [Header("플레이어가 맵밖으로 떨어졌을 때 초기화 하기 위해 필요한 매니저 or 오브젝트")]
    public SequenceAerial sequenceAerial;
    public Grab LGrab;
    public Grab RGrab;

    private void Start()
    {
        vector_StartPosition = transform.position;
    }

    void Update()
    {
        if(transform.position.y <= -20.0f)
        {
            LGrab.RemoveJoint();
            RGrab.RemoveJoint();

            transform.position = vector_StartPosition;
            if(sequenceAerial != null)
            {
                sequenceAerial.ResetSequence();
            }
        }
    }

    public void MoveToTutorialStage()
    {
        objCharacter.transform.position = vector_TutorialStartPosition;
        transform.position = vector_TutorialStartPosition;
        vector_StartPosition = vector_TutorialStartPosition;
    }

    public void CheckPoint(Vector3 vector_CheckPoint)
    {
        vector_StartPosition = vector_CheckPoint;
    }
}
