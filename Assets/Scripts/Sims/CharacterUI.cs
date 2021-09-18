using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _firstNameLabel = null;
    [SerializeField] private TMP_Text _lastNameLabel = null;
    [SerializeField] private TMP_Text _middleInitalLabel = null;
    [SerializeField] private TMP_Text _ageLabel = null;
    [SerializeField] private TMP_Text _marriedLabel = null;
    [SerializeField] private TMP_Text _heightLabel = null;


    public void SetData(Character characterData)
    {
        _firstNameLabel.text = "First Name: " + characterData.FirstName;
        _lastNameLabel.text = "Last Name: " + characterData.LastName;
        _middleInitalLabel.text = "Middle Initial: " + characterData.MiddleInitial;
        _ageLabel.text = "Age: " + characterData.Age;
        _marriedLabel.text = "Married? " + characterData.Married;
        _heightLabel.text = "Height: " + characterData.Height + "in";
    }
}
