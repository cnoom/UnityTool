using UnityEngine;

namespace CnoomUnityTool.UniEvent.Runtime
{
	internal class UniEventDriver : MonoBehaviour
	{
		void Update()
		{
			UniEvent.Update();
		}
	}
}