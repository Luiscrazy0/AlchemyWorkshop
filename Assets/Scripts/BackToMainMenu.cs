using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    public Button backButton;
    public MainMenu mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu = FindObjectOfType<MainMenu>();
        backButton = GetComponent<Button>();
        backButton.onClick.AddListener(OpenMainPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenMainPanel()
    {
        mainMenu.OpenMainPanel();

    }

}
