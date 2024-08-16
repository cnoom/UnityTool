using UnityEngine;

// ReSharper disable CheckNamespace
namespace CnoomUnityTool.UniEvent
{
    internal class UniEventDriver : MonoBehaviour
    {
        private void Update()
        {
            UniEvent.Update();
        }
    }
}