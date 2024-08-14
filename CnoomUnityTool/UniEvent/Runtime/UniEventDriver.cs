using UnityEngine;

namespace CnoomUnityTool.UniEvent.Runtime
{
	internal class UniEventDriver : MonoBehaviour
	{
		void Update()
		{
			ThirdParty.UnityTool.CnoomUnityTool.UniEvent.Runtime.UniEvent.Update();
		}
	}
}