using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    [Header("튜토리얼 레시피")]
    public Sprite[] sprite_OvenTutorialRecipe;
    public Sprite[] sprite_OvenTutorialCreate;
    public Sprite[] sprite_TutorialRecipe;
    public Sprite[] sprite_TutorialCreate;

    [Header("스테이지1 레시피")]
    public Sprite[] sprite_Stage1Recipe;
    public Sprite[] sprite_Stage1Create;

    [Header("스테이지2 레시피")]
    public Sprite[] sprite_Stage2StrawberryTartRecipe;
    public Sprite[] sprite_Stage2StrawberryTartCreate;
    public Sprite[] sprite_Stage2MuscatTartRecipe;
    public Sprite[] sprite_Stage2MuscatTartCreate;
    public Sprite[] sprite_Stage2TartRecipe;
    public Sprite[] sprite_Stage2TartCreate;

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

    public List<Sprite> GetStage1Recipe()
    {
        List<Sprite> list_Stage1Recipe = new List<Sprite>();
        for (int i = 0; i < sprite_Stage1Recipe.Length; i++)
        {
            list_Stage1Recipe.Add(sprite_Stage1Recipe[i]);
        }

        return list_Stage1Recipe;
    }

    public List<Sprite> GetStage1Create()
    {
        List<Sprite> list_Stage1Create = new List<Sprite>();
        for (int i = 0; i < sprite_Stage1Create.Length; i++)
        {
            list_Stage1Create.Add(sprite_Stage1Create[i]);
        }

        return list_Stage1Create;
    }

    public List<Sprite> GetStage2StrawberryTartRecipe()
    {
        List<Sprite> list_Stage2Recipe = new List<Sprite>();
        for (int i = 0; i < sprite_Stage2StrawberryTartRecipe.Length; i++)
        {
            list_Stage2Recipe.Add(sprite_Stage2StrawberryTartRecipe[i]);
        }

        return list_Stage2Recipe;
    }

    public List<Sprite> GetStage2StrawberryTartCreate()
    {
        List<Sprite> list_Stage2Create = new List<Sprite>();
        for (int i = 0; i < sprite_Stage2StrawberryTartCreate.Length; i++)
        {
            list_Stage2Create.Add(sprite_Stage2StrawberryTartCreate[i]);
        }

        return list_Stage2Create;
    }

    public List<Sprite> GetStage2MuscatTartRecipe()
    {
        List<Sprite> list_Stage2Recipe = new List<Sprite>();
        for (int i = 0; i < sprite_Stage2MuscatTartRecipe.Length; i++)
        {
            list_Stage2Recipe.Add(sprite_Stage2MuscatTartRecipe[i]);
        }

        return list_Stage2Recipe;
    }

    public List<Sprite> GetStage2MuscatTartCreate()
    {
        List<Sprite> list_Stage2Create = new List<Sprite>();
        for (int i = 0; i < sprite_Stage2MuscatTartCreate.Length; i++)
        {
            list_Stage2Create.Add(sprite_Stage2MuscatTartCreate[i]);
        }

        return list_Stage2Create;
    }

    public List<Sprite> GetStage2TartRecipe()
    {
        List<Sprite> list_Stage2Recipe = new List<Sprite>();
        for (int i = 0; i < sprite_Stage2TartRecipe.Length; i++)
        {
            list_Stage2Recipe.Add(sprite_Stage2TartRecipe[i]);
        }

        return list_Stage2Recipe;
    }

    public List<Sprite> GetStage2TartCreate()
    {
        List<Sprite> list_Stage2Create = new List<Sprite>();
        for(int i = 0; i < sprite_Stage2TartCreate.Length; i++)
        {
            list_Stage2Create.Add(sprite_Stage2TartCreate[i]);
        }

        return list_Stage2Create;
    }
}
