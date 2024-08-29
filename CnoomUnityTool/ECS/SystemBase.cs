// ReSharper disable CheckNamespace
namespace CnoomUnityTool.ECS
{
    /// <summary>
    /// 系统基类
    /// </summary>
    public abstract class SystemBase
    {
        protected World world;

        public SystemBase(World world)
        {
            this.world = world;
        }

        public abstract void Update();
    }
}