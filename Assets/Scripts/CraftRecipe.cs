using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftRecipe : ElementData
{
    public static List<Recipes> recipes = new List<Recipes>();
    public string potion;


    public void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        PotionEventManager.PotionCreate += CraftedPotion;
        recipes.Add(new Recipes("Sun", new List<string>() { "Gold", "Silver" }));
        recipes.Add(new Recipes("Moon", new List<string>() { "Copper", "Silver" }));
        recipes.Add(new Recipes("Gravity", new List<string>() { "Gold", "Copper" }));

    }

    public void CraftedPotion()
    {
        RaycastManager.instance.chosenElements.Sort();

        for (int i = 0; i < recipes.Count; i++)
        {
            recipes[i].ingredientNames.Sort();
            Debug.Log("sorted recipes" + recipes[i].ingredientNames[0] + " and" + recipes[i].ingredientNames[1]);
            Debug.Log("sorted elements" + RaycastManager.instance.chosenElements[0] + " and" + RaycastManager.instance.chosenElements[1]);


            if (RaycastManager.instance.chosenElements[0] == recipes[i].ingredientNames[0] && RaycastManager.instance.chosenElements[1] == recipes[i].ingredientNames[1])
            {
                potion = recipes[i].name;
                Debug.Log("Potion Created is:  " + potion);
                RaycastManager.instance.itemNameText.text = "Potion Created is:  " + potion;
            }
            else
            {
              //  Debug.Log("No Potion");

            }
        }

    }

}
