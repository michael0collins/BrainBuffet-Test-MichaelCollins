using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour, IGameState
{
    [SerializeField] string _stateName;

    public string StateName => _stateName;

    public virtual void OnStateBegin()
    {
        Debug.Log($"State: {_stateName} has begun.");
    }

    public virtual void OnStateEnd()
    {
        Debug.Log($"State: {_stateName} has ended.");
    }
}
