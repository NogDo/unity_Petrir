using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public List<AudioSource> audioSources;
    public Slider slider_BGM;
    public Slider slider_Sound;

    public Stage stage;

    private void Start()
    {
        // 0, 1은 BGM 나머지는 효과음
        for(int i = 0; i < transform.childCount; i++)
        {
            audioSources.Add(transform.GetChild(i).GetComponent<AudioSource>());
        }

        if(slider_BGM != null)
        {
            slider_BGM.onValueChanged.AddListener(delegate { ChangeBGMVolume(); });
            slider_Sound.onValueChanged.AddListener(delegate { ChangeSoundVolume(); });
        }
    }

    public void ChangeBGMVolume()
    {
        if(stage == Stage.Stage1_5)
        {
            for (int i = 0; i < 3; i++)
            {
                audioSources[i].volume = slider_BGM.value;
            }
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                audioSources[i].volume = slider_BGM.value;
            }
        }
        
    }

    public void ChangeSoundVolume()
    {
        if(stage == Stage.Stage1_5)
        {
            for (int i = 3; i < audioSources.Count; i++)
            {
                audioSources[i].volume = slider_Sound.value;
            }
        }
        else
        {
            for (int i = 2; i < audioSources.Count; i++)
            {
                audioSources[i].volume = slider_Sound.value;
            }
        }
    }
}
