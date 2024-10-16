SimpleUnityTool
===
较为全面且封装简单的unity库
## 如何安装?
```json
{
  "dependencies": {
    "com.cnoom.unitytool": "https://github.com/cnoom/UnityTool.git"
  }
}
```
## [SingletonUtils](Runtime/SingletonUtils) 单例工具库
统一实现一个[ISingleton](Runtime/SingletonUtils/ISingleton.cs)接口,接口具有初始化和释放方法
- [Singleton](Runtime/SingletonUtils/Singleton.cs)
  普通单例
- [SingletonMono](Runtime/SingletonUtils/SingletonMono.cs)
  MonoBehaviour单例,具有一个控制释放切换场景时是否销毁的布尔字段 IsDestroyOnLoad
```c#
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour,ISingleton where T : SingletonMonoBehaviour<T>
{
    private static T? instance;
    private static readonly object Lock = new object();
    protected bool IsDestroyOnLoad = false;
    ...
```

## [StorageUtils](Runtime/StorageUtils) 持久化反持久化工具库
实现一个[IStorage](Runtime/StorageUtils/IStorage.cs)接口,接口具有获取保存是否存在和删除方法
默认实现一个基于PlayerPrefs的封装工具库
需要使用时通过实现[IStorageUser](Runtime/StorageUtils/IStorageUser.cs)接口去使用其中的拓展方法
```C#
IStorageUser s = yourIStorage
int i =  s.GetInt(key:"yourkey",defaultVale:0)
```
如果有其他持久化非持久化实现方式可以通过实现[IStorage](Runtime/StorageUtils/IStorage.cs)接口然后修改对应的IStorage.Current
```c#
{
    IStorage.Current = YourIStorage;
    ...
}
```

## [Extensions](Runtime/Extensions)
常用类拓展
- [ListExtensions](Runtime/Extensions/ListExtensions.cs)
- [NumberExtensions](Runtime/Extensions/NumberExtensions.cs)
- [TransformExtensions](Runtime/Extensions/TransformExtensions.cs)
- [Vector2Extension](Runtime/Extensions/Vector2Extension.cs)
- [Vector3Extension](Runtime/Extensions/Vector3Extension.cs)

## [EventUtil](Runtime/EventUtils)
简易事件系统，目前实现一个类型事件系统
- [TypeEventSystem](Runtime/EventUtils/TypeEventSystem.cs)
类型事件系统,提供弱引用避免忘记取消订阅导致的问题

## [StateMachineUtils](Runtime/StateMachineUtils)
简易状态机，支持链式调用增加状态


