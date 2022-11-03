using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomTipManager : MonoBehaviour
{
    public Sprite[] sprite_Tutorial_Tip;
    public Sprite[] sprite_2Stage_Tip;
    public Sprite[] sprite_4Stage_Tip;
    public Sprite[] sprite_Random_Tip;


    public void RandomTutorialTip()
    {
        int nRandomIndex = Random.Range(0, sprite_Tutorial_Tip.Length);
        GetComponent<Image>().sprite = sprite_Tutorial_Tip[nRandomIndex];
    }

    public void RandomStage2Tip()
    {
        int nRandomIndex = Random.Range(0, sprite_2Stage_Tip.Length);
        GetComponent<Image>().sprite = sprite_2Stage_Tip[nRandomIndex];
    }

    public void RandomStage4Tip()
    {
        int nRandomIndex = Random.Range(0, sprite_4Stage_Tip.Length);
        GetComponent<Image>().sprite = sprite_4Stage_Tip[nRandomIndex];
    }

    public void RandomTip()
    {
        int nRandomIndex = Random.Range(0, sprite_Random_Tip.Length);
        GetComponent<Image>().sprite = sprite_Random_Tip[nRandomIndex];
    }
}
