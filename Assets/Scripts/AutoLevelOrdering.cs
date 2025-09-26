using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLevelOrdering : MonoBehaviour
{
    public LevelBase[] levels;
    public GameObject buttonPrefab;
    public Transform buttonParent;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var level in levels)
        {
            GameObject btnObj = Instantiate(buttonPrefab, buttonParent);
            btnObj.GetComponent<LevelButton>().levelData = level;

        }
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
