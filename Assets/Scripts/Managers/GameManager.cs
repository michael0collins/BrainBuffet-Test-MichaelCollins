using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Game State")]
    [SerializeField] string _startingStateName = "";
    [SerializeField] bool _useStartState;
    [SerializeField] List<GameState> _gameStates = new List<GameState>();

    GameState _currentState = null;
    bool _changingState = false;

    public event Action OnStateChanged = delegate { };

    void Start()
    {
        if (_useStartState)
            ChangeGameState(_startingStateName);
    }

    public void ChangeGameState(string stateName)
    {
        if (_changingState == false)
            StartCoroutine(ChangeGameStateRoutine(stateName));
        else
            Debug.Log("State change is busy but being called.");
    }

    IEnumerator ChangeGameStateRoutine(string newStateName)
    {
        if (_currentState != null && _currentState.StateName == newStateName)
        {
            Debug.Log($"Trying to enable the same state: {newStateName}");
            yield break;
        }

        _changingState = true;

        if (_currentState != null)
        {
            _currentState.OnStateEnd();
            yield return 0;
            _currentState.gameObject.SetActive(false);
            _currentState = null;
        }

        if (newStateName == "None")
        {
            Debug.Log("Setting state to None.");
            _changingState = false;
            yield break;
        }

        foreach (var g in _gameStates)
            if (g.StateName == newStateName)
                _currentState = g;

        if (_currentState == null)
        {
            Debug.Log($"No state found named: {newStateName}");
            yield break;
        }

        _currentState.gameObject.SetActive(true);
        yield return 0;
        _currentState.OnStateBegin();

        _changingState = false;
    }
}