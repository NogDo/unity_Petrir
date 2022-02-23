using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public Sprite[] sprite_OvenTutorialRecipe;
    public Sprite[] sprite_OvenTutorialCreate;
    public Sprite[] sprite_TutorialRecipe;
    public Sprite[] sprite_TutorialCreate;

    public List<Sprite> GetTutorialRecipe()
    {
        List<Sprite> list_TutorialRecipe = new List<Sprite>();
        for(int i = 0; i < sprite_TutorialRecipe.Length; i++)
        {
            list_TutorialRecipe.Add(sprite_TutorialRecipe[i]);
        }

        return list_TutorialRecipe;
    }

    public List<Sprite> GetTutorialCreate()
    {
        List<Sprite> list_TutorialCreate = new List<Sprite>();
        for (int i = 0; i < sprite_TutorialRecipe.Length; i++)
        {
            list_TutorialCreate.Add(sprite_TutorialCreate[i]);
        }

        return list_TutorialCreate;
    }

    public List<Sprite> GetOvenTutorialRecipe()
    {
        List<Sprite> list_OvenTutorialRecipe = new List<Sprite>();
        for(int i = 0; i < sprite_OvenTutorialRecipe.Length; i++)
        {
            list_OvenTutorialRecipe.Add(sprite_OvenTutorialRecipe[i]);
        }

        return list_OvenTutorialRecipe;
    }

    public List<Sprite> GetOvenTutorialCreate()
    {
        List<Sprite> list_OvenTutorialCreate = new List<Sprite>();
        for (int i = 0; i < sprite_OvenTutorialCreate.Length; i++)
        {
            list_OvenTutorialCreate.Add(sprite_OvenTutorialCreate[i]);
        }

        return list_OvenTutorialCreate;
    }
}
