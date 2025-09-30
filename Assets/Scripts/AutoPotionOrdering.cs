using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPotionOrdering : MonoBehaviour
{
    public PotionInstance[] potions;
    public GameObject buttonPrefab;
    public Transform buttonParent;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var potion in potions)
        {
            GameObject btnObj = Instantiate(buttonPrefab, buttonParent);
            btnObj.GetComponent<PotionButton>().potion = potion;

        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
