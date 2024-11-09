using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cnoom.UnityTool.StateMachineUtils
{
    public class StateMachine<T>
    {
        protected Dictionary<T, IState> States = new Dictionary<T, IState>();
        private IState currentState;
        public T CurrentStateId {get; private set;}
        public T PreviousStateId { get; private set; }
        private Action<T, T> onStateChanged = (_, __) => { };
        public long FrameCountOfCurrentState = 1;
        public float SecondsOfCurrentState = 0.0f;

        public void AddState(T key, IState state)
        {
            States.Add(key, state);
        }


        public void ChangeState(T key)
        {
            if(key.Equals(CurrentStateId)) return;
            if (States.TryGetValue(key, out var state))
            {
                if (currentState != null && state.Condition())
                {
                    currentState.Exit();
                    PreviousStateId = CurrentStateId;
                    currentState = state;
                    CurrentStateId = key;
                    onStateChanged?.Invoke(PreviousStateId, CurrentStateId);
                    FrameCountOfCurrentState = 1;
                    SecondsOfCurrentState = 0.0f;
                    currentState.Enter();
                }
            }
        }
        
        public void OnStateChanged(Action<T, T> onStateChanged)
        {
            this.onStateChanged += onStateChanged;
        }
        
        public void StartState(T t)
        {
            if (States.TryGetValue(t, out var state))
            {
                PreviousStateId = t;
                currentState = state;
                CurrentStateId = t;
                FrameCountOfCurrentState = 0;
                SecondsOfCurrentState = 0.0f;
                state.Enter();
            }
        }
        
        public void Update()
        {
            currentState?.Update();
            FrameCountOfCurrentState++;
            SecondsOfCurrentState += Time.deltaTime;
        }
        
        public void Clear()
        {
            currentState = null;
            CurrentStateId = default;
            States.Clear();
        }
    }
}