using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public List<Sprite> list_Material;

    public TutorialManager tutorialManager;
    public OvenManager ovenManager;

    private bool isEndChestTutorial;

    private void Start()
    {
        isEndChestTutorial = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (tutorialManager.IsStartChestTutorial() && !isEndChestTutorial && (ovenManager.stage == Stage.Oven))
            {
                tutorialManager.EndChestTutorial();
                isEndChestTutorial = true;
            }

            other.gameObject.SetActive(false);
            list_Material.Add(other.gameObject.GetComponent<ObjectManager>().sprite_ObjectImage);
        }
    }

    public List<Sprite> GetMaterialList()
    {
        return list_Material;
    }
}
