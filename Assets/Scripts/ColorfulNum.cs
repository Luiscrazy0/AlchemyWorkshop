using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorfulNum : MonoBehaviour
{
    public IngrediantsBase ingrediantData;

    // Start is called before the first frame update
    void Start()
    {
        var info = ingrediantData.GetElementInfo();
        var numText = GetComponent<TMP_Text>();

        numText.text = info.value.ToString();
        numText.color = info.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
