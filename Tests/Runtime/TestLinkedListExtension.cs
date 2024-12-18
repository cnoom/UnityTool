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
    public void ForeachUntilTest1()
    {
        var linkedList = DefaultList();
        linkedList.Sort(Comparer<int>.Default);
        int count = 0;
        var condition = new Func<int, bool>(x =>
        {
            count++;
            return x == 5;
        });
        linkedList.ForeachUntil(condition);
        Assert.AreEqual(3, count);
    }

    [Test]
    public void ForeachUntilTest2()
    {
        var linkedList = DefaultList();
        int count = 0;
        var condition = new Func<int, bool>(x =>
        {
            count++;
            return x == 1000;
        });
        linkedList.ForeachUntil(condition);
        Assert.AreEqual(linkedList.Count, count);
    }
}