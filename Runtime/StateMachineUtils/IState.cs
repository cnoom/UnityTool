namespace Cnoom.UnityTool.StateMachineUtils
{
    public interface IState
    {
        bool Condition();
        void Enter();
        void Update();
        void Exit();
    }
}