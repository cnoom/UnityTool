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
## [ActionUtils](Runtime/ActionUtils) 延迟行动库
实现一个支持延迟指定帧数和指定毫秒数执行的延迟行动系统


## [SingletonUtils](Runtime/SingletonUtils) 单例工具库
统一实现一个[ISingleton](Runtime/SingletonUtils/ISingleton.cs)接口,接口具有初始化和释放方法
- [Singleton](Runtime/SingletonUtils/Singleton.cs)
  普通单例,继承自[ISingleton](Runtime/SingletonUtils/ISingleton.cs)，使用时需要实现私有无参构造函数
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
默认实现一个基于PlayerPrefs的封装工具库：通过实现[PlayerPrefsStorage](Runtime/StorageUtils/PlayerPrefsStorage.cs)调用其中的拓展方法去保存/获取存储数据
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

## [LogUtils](RunTime/LogUtils) 输出工具库
实现一个this.log输出类型的工具用来快速输出，默认输出白色警告输出黄色异常输出红色，支持自定义输出格式类型，默认输出格式为 "ClassName:message"

## [Extensions](Runtime/Extensions)
常用类拓展，对应拓展类包含如下方法【以扩展类名区分】【待完善】
- [ArrayExtension](Runtime/Extensions/ArrayExtension.cs) 清空数组为默认值，获取随机元素，统一设定为某个值
- [BoolExtension](Runtime/Extensions/BoolExtension.cs) 布尔值转换为01，布尔值转换为一对相反数
- [ComponentExtension](Runtime/Extensions/ComponentExtension.cs) 获取或添加指定类型的组件
- [DictionaryExtension](Runtime/Extensions/DictionaryExtension.cs) 获取指定键的值，并将其转换为指定的子类型
- [LinkedListExtension](Runtime/Extensions/LinkedListExtension.cs) 快速排序以及归并排序
- [ListExtension](Runtime/Extensions/ListExtension.cs) 根据条件查找元素、移除元素，获取随机元素
- [NumberExtension](Runtime/Extensions/NumberExtension.cs) 获取绝对值
- [TransformExtension](Runtime/Extensions/TransformExtension.cs) 查找/添加指定路径子物体身上的组件，查找指定路径的子物体的特定某组件
- [Vector2Extension](Runtime/Extensions/Vector2Extension.cs) 将当前向量修改某个特定值，将当前向量的各方向值设为特定值，求距离以及距离平方
- [Vector3Extension](Runtime/Extensions/Vector3Extension.cs) 同上

## [EventUtil](Runtime/EventUtils)
简易事件系统，目前实现一个类型事件系统
- [TypeEventSystem](Runtime/EventUtils/TypeEventSystem.cs)
类型事件系统

## [StateMachineUtils](Runtime/StateMachineUtils)
简易状态机，支持链式调用增加状态

## [MaterialUtils](Runtime/MaterialUtils)
目前实现了根据材质偏移实现精灵/图片滚动效果的mono,需要修改贴图间拼接模式为重复,材质shader为unlit/Transparent


