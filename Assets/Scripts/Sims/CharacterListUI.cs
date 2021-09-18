using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterListUI : MonoBehaviour
{
    [SerializeField] private CharacterUI _prefab = null;
    [SerializeField] private Transform _parentContainer = null;

    private List<Character> _characters = new List<Character>();

    void Start()
    {
        _characters = new List<Character>()
        {
            new Character("James", "Buchanan", 'C',  77, false, 72 ),
            new Character("John", "Adams", 'Q',  80, false, 66 ),
            new Character("Bill", "Clinton", 'J',  75, false, 72 ),
            new Character("George", "Washington", 'C',  67, false, 72 ),
            new Character("George", "Bush", 'W',  75, false, 73 )
        };

        PopulateList();
    }

    private void PopulateList()
    {
        foreach (Character character in _characters)
        {
            CharacterUI characterUI = Instantiate(_prefab, _parentContainer);
            characterUI.SetData(character);
            characterUI.gameObject.SetActive(true);
        }
    }
}
