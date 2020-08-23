using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftRecipe : MonoBehaviour
{
    public static List<Recipes> recipes = new List<Recipes>();
    public string potion;
    public static CraftRecipe instance;


    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        recipes.Add(new Recipes("Sun", new List<string>() { "Gold", "Mercury" }));
        recipes.Add(new Recipes("Moon", new List<string>() { "Silver", "Mercury" }));
        recipes.Add(new Recipes("Feather", new List<string>() { "Salt", "Silver" }));
        recipes.Add(new Recipes("Strength", new List<string>() { "Iron", "Salt" }));
        recipes.Add(new Recipes("Fertility", new List<string>() { "Copper", "Iron" }));
        recipes.Add(new Recipes("Shrinking", new List<string>() { "Copper", "Tin" }));
        recipes.Add(new Recipes("Electric", new List<string>() { "Silver", "Lead" }));
        recipes.Add(new Recipes("Heavy", new List<string>() { "Mercury", "Lead" }));
        recipes.Add(new Recipes("Sound", new List<string>() { "Salt", "Gold" }));


    }

    public string CraftedPotion()
    {
        RaycastManager.instance.chosenElements.Sort();

        for (int i = 0; i < recipes.Count; i++)
        {
            recipes[i].ingredientNames.Sort();
            //Debug.Log("sorted recipes" + recipes[i].ingredientNames[0] + " and" + recipes[i].ingredientNames[1]);
            Debug.Log("sorted elements" + RaycastManager.instance.chosenElements[0] + " and" + RaycastManager.instance.chosenElements[1]);


            if (RaycastManager.instance.chosenElements[0] == recipes[i].ingredientNames[0] && RaycastManager.instance.chosenElements[1] == recipes[i].ingredientNames[1])
            {
                potion = recipes[i].name;
                Debug.Log("Potion Created is:  " + potion);
                RaycastManager.instance.itemNameText.text = "Potion Created is:  " + potion;
                return potion;

            }

        }
        return "None";

    }

}
