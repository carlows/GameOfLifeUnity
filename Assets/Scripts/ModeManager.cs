using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ModeManager : MonoBehaviour {
    private Modo _currentModo = Modo.Conways;
    private IRuleStrategy _currentStrategy;
    private GridManager _manager;
    public Text _modoText;
	// Use this for initialization
	void Start () {
        _manager = GetComponent<GridManager>();
        _currentStrategy = RuleFactory.GetInstance(_currentModo);
        UpdateText();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeMode();
        }
	}

    private void ChangeMode()
    {
        int current = (int)_currentModo;
        current = (current + 1) % Enum.GetNames(typeof(Modo)).Length;

        _currentModo = (Modo)current;
        _currentStrategy = RuleFactory.GetInstance(_currentModo);

        UpdateText();
        _manager.setModeAndRestart(_currentStrategy);
    }

    private void UpdateText()
    {
        _modoText.text = String.Format("MODO (Tab): {0}", _currentStrategy.getName());
    }   
}
