using System;

namespace Cnoom.UnityTool.StateMachineUtils
{
    public static class StateMachineExtension
    {
        public static AbstractState AddState<T>(this StateMachine<T> machine, T key)
        {
            AbstractState abstractState = new AbstractState();
            machine.AddState(key, abstractState);
            return abstractState;
        }

        public static AbstractState OnCondition(this AbstractState state, Func<bool> condition)
        {
            return state.OnCondition(condition);
        }

        public static AbstractState OnEnter(this AbstractState state, Action enter)
        {
            return state.OnEnter(enter);
        }

        public static AbstractState OnUpdate(this AbstractState state, Action update)
        {
            return state.OnUpdate(update);
        }

        public static AbstractState OnExit(this AbstractState state, Action exit)
        {
            return state.OnExit(exit);
        }

    }
}