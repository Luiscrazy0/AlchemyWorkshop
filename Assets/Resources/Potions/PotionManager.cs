using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public PotionBase currentPotionConfig;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PotionInstance GeneratePotionResult(int playerScore)//玩家分数的十分之一是丹药品质，10分以下炼废丹。
                                                               //该函数返回一个丹药实例用于记录品质种类和品级，存在背包系统里可以售卖
    {
        PotionInstance result = new PotionInstance();
        result.finalQuality = playerScore/10;
        if(result.finalQuality == 0)
        {
            result.potion = GameAssets.BadPotion;
        }
        else
        {
            result.potion = currentPotionConfig;
        }
            

        return result;

    }
}
