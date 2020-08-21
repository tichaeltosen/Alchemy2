using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipes
{
    public string name; 
    public List<string> ingredientNames;

    public Recipes(string _name, List<string> _ingredientNames)
    {
        name = _name;
        ingredientNames = _ingredientNames;
    }


}
