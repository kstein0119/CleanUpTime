using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientChecker : MonoBehaviour
{
    public BoxCollider2D coffeePot;
    public BoxCollider2D milkJug;
    public BoxCollider2D chocoSauce;
    public BoxCollider2D mug;

    public void CoffeeInMug()
    {
        if (coffeePot.IsTouching(mug))
        {
            print("Coffee in mug");
        }

        
    }


}
