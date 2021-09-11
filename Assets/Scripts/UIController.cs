using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private int _keysRequired;
    [SerializeField] private GameObject _victoryLabel = null;
    [SerializeField] private TMP_Text _keysLabel = null;

    private int _keysCollected = 0;

    private static UIController _instance = null;
    public static UIController Instance
    {
        get
        {
            if(_instance == null) 
            { 
                _instance = FindObjectOfType<UIController>(); 
            }

            return _instance;
        }
    }

    private void Start()
    {
        if (_victoryLabel != null)
        {
            _victoryLabel?.SetActive(false);
        }
    }

    public void OnKeyCollected()
    {
        _keysCollected++;
        UpdateKeyLabel();

        if (_keysCollected == _keysRequired)
        {
            OnComplete();
        }
    }

    private void OnComplete()
    {
        _victoryLabel?.SetActive(true);
    }

    private void UpdateKeyLabel()
    {
        _keysLabel?.SetText("Keys: " + _keysCollected + "/" + _keysRequired);
    }
}
