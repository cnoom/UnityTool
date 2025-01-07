using System;
using UnityEngine;

namespace Cnoom.UnityTool.MaterialUtils
{
    public abstract class AMaterialScroll : MonoBehaviour
    {
        public enum ScrollType
        {
            Follow,
            Auto
        }
        private const float Rate = 0.01f;
        [Tooltip("移动的速率比")]
        public float speed;
        [Tooltip("移动的方向")]
        public Vector2 direction;
        [Tooltip("移动的类型")]
        public ScrollType scrollType;
        [Tooltip("跟随的目标")]
        public Transform follower;

        protected abstract Material GetMaterial();
        private Material material;
        private Vector2 lastOffset;
        private bool isPause;
        protected virtual void Awake()
        {
            TryInitFollowPosition();
        }

        protected virtual void Start()
        {
            UpdateMaterial();
        }

        private void Update()
        {
            if(isPause) return;
            TryAuto();
            TryFollow();
        }

        public void Pause()
        {
            isPause = true;
        }

        public void Resume()
        {
            isPause = false;
        }

        private void TryAuto()
        {
            if(scrollType != ScrollType.Auto) return;
            material.mainTextureOffset += speed * Rate * Time.deltaTime * direction.normalized;
        }

        private void TryFollow()
        {
            if(scrollType != ScrollType.Follow) return;
            Vector2 dis = (Vector2)follower.position - lastOffset;
            material.mainTextureOffset += speed * Rate * Time.deltaTime * dis;
            lastOffset = follower.position;
        }

        private void TryInitFollowPosition()
        {
            if(scrollType != ScrollType.Follow) return;
            lastOffset = follower.position;
        }

        protected void UpdateMaterial()
        {
            material = GetMaterial();
        }
    }
}