using System;
using System.Collections.Generic;
using System.Linq;
using Cnoom.UnityTool.Extensions;
using NUnit.Framework;

[TestFixture]
public class LinkedListSortTest
{
    private LinkedList<int> DefaultList()
    {
        var linkedList = new LinkedList<int>();
        linkedList.AddLast(5);
        linkedList.AddLast(3);
        linkedList.AddLast(8);
        linkedList.AddLast(1);
        linkedList.AddLast(6);
        linkedList.AddLast(5);
        return linkedList;
    }

    private List<int> TrueList()
    {
        return new List<int>
        {
            1,
            3,
            5,
            5,
            6,
            8,
        };
    }

    [Test]
    public void QuickSortTest()
    {
        // 创建一个包含一些元素的链表

        var linkedList = DefaultList();

        // 创建比较器
        var comparer = Comparer<int>.Default;

        // 调用排序方法
        linkedList.QuickSort(comparer);

        // 验证排序结果
        CollectionAssert.AreEqual(TrueList(), linkedList.ToList());
    }

    [Test]
    public void SortTest()
    {
        var linkedList = DefaultList();

        // 创建比较器
        var comparer = Comparer<int>.Default;

        // 调用排序方法
        linkedList.Sort(comparer);

        // 验证排序结果
        CollectionAssert.AreEqual(TrueList(), linkedList.ToList());
    }

    [Test]
    public void ForeachUntil_ShouldExecuteActionWhenConditionMet()
    {
        // 准备测试数据，创建一个LinkedList<int>
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddLast(1);
        linkedList.AddLast(3);
        linkedList.AddLast(5);

        bool actionExecuted = false;
        // 定义条件判断委托，当元素值等于3时满足条件
        Func<int, bool> condition = num => num == 3;
        // 定义要执行的操作委托，这里只是简单设置一个标记表示执行了操作
        Action<int> action = num =>
        {
            actionExecuted = true;
            Assert.AreEqual(3, num);
        };

        // 调用要测试的扩展方法
        linkedList.ForeachUntil(condition, action);

        // 断言操作委托被执行了（即满足条件后执行了相应操作）
        Assert.IsTrue(actionExecuted);
    }

    [Test]
    public void ForeachUntil_ShouldNotExecuteActionWhenConditionNotMet()
    {
        // 准备测试数据，创建一个LinkedList<int>
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddLast(1);
        linkedList.AddLast(3);
        linkedList.AddLast(5);

        bool actionExecuted = true; // 初始化为true，期望不会执行action从而保持为true
        // 定义条件判断委托，当元素值等于10时满足条件（这里故意设置一个不会满足的条件）
        Func<int, bool> condition = num => num == 10;
        // 定义要执行的操作委托，这里只是简单设置一个标记表示执行了操作
        Action<int> action = num => actionExecuted = false;

        // 调用要测试的扩展方法
        linkedList.ForeachUntil(condition, action);

        // 断言操作委托没有被执行（即条件未满足时不应执行相应操作）
        Assert.IsTrue(actionExecuted);
    }

    [Test]
    public void ForeachUntil_ShouldHandleEmptyListCorrectly()
    {
        // 创建一个空的LinkedList<int>
        LinkedList<int> linkedList = new LinkedList<int>();

        bool actionExecuted = false;
        // 定义条件判断委托，随便设置一个条件，因为链表为空不会执行操作
        Func<int, bool> condition = num => num == 3;
        // 定义要执行的操作委托，这里只是简单设置一个标记表示执行了操作
        Action<int> action = num => actionExecuted = true;

        // 调用要测试的扩展方法
        linkedList.ForeachUntil(condition, action);

        // 断言操作委托没有被执行（空链表时不应执行操作）
        Assert.IsFalse(actionExecuted);
    }
    
    [Test]
    public void ForeachUntilNode_ShouldExecuteActionWhenConditionMet()
    {
        // 创建一个LinkedList<int>并添加元素
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddLast(1);
        linkedList.AddLast(3);
        linkedList.AddLast(5);

        // 获取链表的第一个节点作为起始节点用于测试
        LinkedListNode<int> startNode = linkedList.First;
        bool actionExecuted = false;
        // 定义条件判断委托，当元素值等于3时满足条件
        Func<int, bool> condition = num => num == 3;
        // 定义要执行的操作委托，这里只是简单设置一个标记表示执行了操作
        Action<LinkedListNode<int>> action = num =>
        {
            actionExecuted = true;
            Assert.AreEqual(3, num.Value);
        };

        // 调用要测试的扩展方法
        startNode.ForeachUntil(condition, action);

        // 断言操作委托被执行了（即满足条件后执行了相应操作）
        Assert.IsTrue(actionExecuted);
    }

    [Test]
    public void ForeachUntilNode_ShouldNotExecuteActionWhenConditionNotMet()
    {
        // 创建一个LinkedList<int>并添加元素
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddLast(1);
        linkedList.AddLast(3);
        linkedList.AddLast(5);

        // 获取链表的第一个节点作为起始节点用于测试
        LinkedListNode<int> startNode = linkedList.First;
        bool actionExecuted = true; // 初始化为true，期望不会执行action从而保持为true
        // 定义条件判断委托，当元素值等于10时满足条件（这里故意设置一个不会满足的条件）
        Func<int, bool> condition = num => num == 10;
        // 定义要执行的操作委托，这里只是简单设置一个标记表示执行了操作
        Action<LinkedListNode<int>> action = num => actionExecuted = false;

        // 调用要测试的扩展方法
        startNode.ForeachUntil(condition, action);

        // 断言操作委托没有被执行（即条件未满足时不应执行相应操作）
        Assert.IsTrue(actionExecuted);
    }

    [Test]
    public void ForeachUntilNode_ShouldHandleEndOfListCorrectly()
    {
        // 创建一个LinkedList<int>并添加元素
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddLast(1);
        linkedList.AddLast(3);
        linkedList.AddLast(5);

        // 获取链表的最后一个节点作为起始节点用于测试，这样条件大概率不会满足，会遍历到链表末尾
        LinkedListNode<int> startNode = linkedList.Last;
        bool actionExecuted = false;
        // 定义条件判断委托，当元素值等于10时满足条件（故意设置不满足的条件）
        Func<int, bool> condition = num => num == 10;
        // 定义要执行的操作委托，这里只是简单设置一个标记表示执行了操作
        Action<LinkedListNode<int>> action = num => actionExecuted = true;

        // 调用要测试的扩展方法
        startNode.ForeachUntil(condition, action);

        // 断言操作委托没有被执行（遍历到链表末尾没满足条件时不应执行操作）
        Assert.IsFalse(actionExecuted);
    }

    [Test]
    public void ForeachUntilNode_ShouldHandleNullNodeCorrectly()
    {
        // 直接使用null作为起始节点测试（模拟错误传入情况）
        LinkedListNode<int> startNode = null;
        bool actionExecuted = false;
        // 定义条件判断委托，随便设置一个条件（因为节点为null不应执行操作所以条件不重要）
        Func<int, bool> condition = num => num == 3;
        // 定义要执行的操作委托，这里只是简单设置一个标记表示执行了操作
        Action<LinkedListNode<int>> action = num => actionExecuted = true;

        try
        {
            // 调用要测试的扩展方法，预期会抛出异常
            startNode.ForeachUntil(condition, action);
            Assert.Fail("Expected an exception when node is null");
        }
        catch (ArgumentNullException)
        {
            // 捕获到期望的ArgumentNullException异常，说明方法对null节点处理正确
            Assert.IsFalse(actionExecuted);
        }
    }
}