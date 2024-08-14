// ReSharper disable CheckNamespace
namespace CnoomUnityTool.UniMachine.Runtime
{
	public interface IStateNode
	{
		void OnCreate(StateMachine machine);
		void OnEnter();
		void OnUpdate();
		void OnExit();
	}
}