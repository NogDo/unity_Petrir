using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public Sprite sprite_Biscuit;
    public Sprite sprite_Marshmallow;
    public Sprite sprite_Chocolate;
    public Sprite sprite_Smore1;
    public Sprite sprite_Smore2;
    public Sprite sprite_Smore3;
    public Sprite sprite_Smore4;

    public List<Sprite> GetTutorialRecipe()
    {
        List<Sprite> list_TutorialRecipe = new List<Sprite>();
        list_TutorialRecipe.Add(sprite_Biscuit);
        list_TutorialRecipe.Add(sprite_Marshmallow);
        list_TutorialRecipe.Add(sprite_Chocolate);
        list_TutorialRecipe.Add(sprite_Biscuit);

        return list_TutorialRecipe;
    }

    public List<Sprite> GetTutorialCreate()
    {
        List<Sprite> list_TutorialCreate = new List<Sprite>();
        list_TutorialCreate.Add(sprite_Smore1);
        list_TutorialCreate.Add(sprite_Smore2);
        list_TutorialCreate.Add(sprite_Smore3);
        list_TutorialCreate.Add(sprite_Smore4);

        return list_TutorialCreate;
    }
}
