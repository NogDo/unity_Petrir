using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_MovePoint : MonoBehaviour
{
    public GameObject objPlayer;

    public TutorialManager tutorialManager;

    private int nInMovePoiuntCount;

    private void Start()
    {
        nInMovePoiuntCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject == objPlayer)
        {
            if(nInMovePoiuntCount == 0)
            {
                Debug.Log("걷기 튜토리얼 종료");
                tutorialManager.EndWalkTutorial();
                nInMovePoiuntCount++;
                gameObject.SetActive(false);
            }
            else if(nInMovePoiuntCount == 1)
            {
                Debug.Log("뛰기 튜토리얼 종료");
                tutorialManager.EndRunTutorial();
                nInMovePoiuntCount++;
                gameObject.SetActive(false);
            }
            
        }
    }
}
