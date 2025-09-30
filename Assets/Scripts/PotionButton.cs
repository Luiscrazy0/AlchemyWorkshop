using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionButton : MonoBehaviour
{
    public PotionInstance potion;
    public TMP_Text potionText;
    public Button potionButton;
    public Sprite potionImage;


    // Start is called before the first frame update
    void Start()
    {
        potionButton = GetComponent<Button>();
        GetComponent<Image>().sprite = potionImage;
        potionText = potionButton.GetComponentInChildren<TMP_Text>();
        potionButton.onClick.AddListener(SellOrNot);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SellOrNot()
    {

    }
}
