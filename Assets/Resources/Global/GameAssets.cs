using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameAssets 
{
    private static PotionBase _badPotion;
    public static PotionBase BadPotion 
    {
        get
        {
        if ( _badPotion == null)
            {
                _badPotion = Resources.Load<PotionBase>("Potions/badPotion");
            }
        
        return _badPotion;
        }
        
    }

    public static bool GameFail = false;
}
