using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TitleController : MonoBehaviour
{
    public GameObject mainMenu = null;
    public GameObject optionsMenu = null;

    public Slider _volumeSlider = null;
    public Toggle _vsyncToggle = null;
    public TMP_Dropdown _dropDown = null;

    public float _volume = 1;
    public bool _vsync = true;
    public int _languageSelected = 0;

    // Start is called before the first frame update
    void Start()
    {
        _vsyncToggle.isOn = _vsync;
        _volumeSlider.value = _volume;
        _dropDown.value = _languageSelected;

        _vsyncToggle.onValueChanged.AddListener(OnToggle_Vsync);
        _volumeSlider.onValueChanged.AddListener(OnValueChanged_Volume);
        _dropDown.onValueChanged.AddListener(OnDropdown_Language);
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

    public void OnToggle_Vsync(bool value)
    {
        _vsync = value;

        Debug.LogError("Vsync: " + value);
    }

    public void OnValueChanged_Volume(float volume)
    {
        _volume = volume;

        Debug.LogError("Volume: " + volume);
    }

    public void OnDropdown_Language(int index)
    {
        _languageSelected = index;

        Debug.LogError("Language: " + _dropDown.options[index].text);
    }
}
