using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionInstance : MonoBehaviour
{
    public PotionBase potion;
    public int price;
    public int grade;

    // Start is called before the first frame update
    void Start()
    {
        price = grade * (int)Mathf.Pow(10,potion.baseQuality); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
