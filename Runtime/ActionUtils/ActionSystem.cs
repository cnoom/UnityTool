using System;
using System.Collections.Generic;
using System.Linq;
using Cnoom.UnityTool.SingletonUtils;
using UnityEngine;

namespace Cnoom.UnityTool.ActionUtils
{
    public class ActionSystem : SingletonMonoBehaviour<ActionSystem>
    {
        public override bool IsDestroyOnLoad => false;

        private readonly List<Processor> processors = new List<Processor>();
        private readonly List<Processor> processorsToRemove = new List<Processor>();
        
        private void Update()
        {
            processorsToRemove.AddRange(processors);
            foreach (Processor p in processorsToRemove.Where(p => p.Execute()))
            {
                processors.Remove(p);
            }
            processorsToRemove.Clear();
        }

        /// <summary>
        /// 在指定的帧执行一次动作
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="action"></param>
        public void ActionFrame(int frame, Action action)
        {
            processors.Add(new Processor(action, frame, DelayType.Frame));
        }

        /// <summary>
        /// 在指定的毫秒执行一次动作
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <param name="action"></param>
        public void ActionMillisecond(int milliseconds, Action action)
        {
            processors.Add(new Processor(action, milliseconds, DelayType.Milliseconds));
        }

        private class Processor
        {
            private Action action;
            private int delay;
            private DelayType delayType;

            public Processor(Action action, int delay, DelayType delayType)
            {
                this.action = action;
                this.delay = delay;
                this.delayType = delayType;
            }

            public bool Execute()
            {
                switch(delayType)
                {
                    case DelayType.Frame:
                        return FrameDelay();
                    case DelayType.Milliseconds:
                        return MillisecondsDelay();
                }
                return true;
            }

            private bool FrameDelay()
            {
                delay--;
                if(delay >= 1) return false;
                action();
                return true;
            }

            private bool MillisecondsDelay()
            {
                delay -= (int)(Time.deltaTime * 1000);
                if(delay >= 1) return false;
                action();
                return true;
            }
        }

        private enum DelayType
        {
            /// <summary>
            /// 帧
            /// </summary>
            Frame,
            /// <summary>
            /// 毫秒
            /// </summary>
            Milliseconds,
        }
    }
}