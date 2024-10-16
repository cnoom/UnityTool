using System;

namespace Cnoom.UnityTool.StateMachineUtils
{
    public class AbstractState : IState
    {
        Func<bool> condition;
        Action onEnter, onUpdate, onExit;

        public AbstractState OnCondition(Func<bool> c)
        {
            condition = c;
            return this;
        }

        public AbstractState OnEnter(Action a)
        {
            onEnter += a;
            return this;
        }

        public AbstractState OnUpdate(Action a)
        {
            onUpdate += a;
            return this;
        }

        public AbstractState OnExit(Action a)
        {
            onExit += a;
            return this;
        }
            
        public bool Condition()
        {
            return condition == null || condition.Invoke();
        }
        public void Enter()
        {
            onEnter?.Invoke();
        }
        public void Update()
        {
            onUpdate?.Invoke();
        }
        public void Exit()
        {
            onExit?.Invoke();
        }
    }
}