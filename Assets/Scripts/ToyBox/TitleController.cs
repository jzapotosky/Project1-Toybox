using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public GameObject mainMenu = null;
    public GameObject optionsMenu = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClick_Options()
    {
        // Turn off main Menu
        mainMenu.SetActive(false);
        // Turn on options Menu
        optionsMenu.SetActive(true);
    }

    public void OnClick_Menu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
