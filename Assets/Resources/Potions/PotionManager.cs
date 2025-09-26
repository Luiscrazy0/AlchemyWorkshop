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

    public PotionInstance GeneratePotionResult(int playerScore)//��ҷ�����ʮ��֮һ�ǵ�ҩƷ�ʣ�10���������ϵ���
                                                               //�ú�������һ����ҩʵ�����ڼ�¼Ʒ�������Ʒ�������ڱ���ϵͳ���������
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
