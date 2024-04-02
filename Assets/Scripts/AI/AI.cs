using System;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class AI : MonoBehaviour
{
    [HideInInspector] public Unit unit;
    [SerializeField] public State currentState;
    [HideInInspector] public float stateTimeElapsed;

    [HideInInspector] public Transform target;
    [HideInInspector] public Vector2 spawnPos;
    [HideInInspector] public Vector2 currentDir;
    [HideInInspector] public float actionTp1 = 0f;
    [HideInInspector] public float actionTp2 = 0f;
    [HideInInspector] public float actionTime1 = 0f;
    [HideInInspector] public float actionTime2 = 0f;
    
    private void Awake()
    {
        unit = GetComponent<Unit>();
        spawnPos = transform.position;
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != null)
        {
            OnExitState();
            currentState = nextState;
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return stateTimeElapsed >= duration;
    }

    public void OnExitState()
    {
        actionTp1 = 0f;
        actionTp2 = 0f;
        stateTimeElapsed = 0;
    }
}