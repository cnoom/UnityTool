using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Cnoom.UnityTool.Extensions
{
    public static class LinkedListExtension
    {
        /// <summary>
        /// 遍历链表，直到满足条件
        /// </summary>
        /// <param name="list"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        public static void ForeachUntil<T>([NotNull] this LinkedList<T> list, [NotNull] Func<T, bool> condition)
        {
            LinkedListNode<T> current = list.First;
            while (current != null)
            {
                if(condition(current.Value))
                {
                    // 满足条件，退出遍历
                    break;
                }
                current = current.Next;
            }
        }

        #region Sort

        /// <summary>
        /// 使用快速排序进行排序
        /// </summary>
        /// <param name="self"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        public static void QuickSort<T>([NotNull] this LinkedList<T> self, [NotNull] Comparer<T> comparer)
        {
            QuickSort(self, comparer, self.First, self.Last);
        }

        private static void QuickSort<T>(LinkedList<T> list, Comparer<T> comparer, LinkedListNode<T> start, LinkedListNode<T> end)
        {
            if(start != null && end != null && start != end && start != end.Next)
            {
                // 选择最后一个节点作为基准值（也可以选择其他合适的选择方式来优化）
                T pivot = end.Value;
                LinkedListNode<T> i = start;
                LinkedListNode<T> j = start;

                while (j != end)
                {
                    if(comparer.Compare(j.Value, pivot) <= 0)
                    {
                        // 交换i和j节点的值
                        T temp = i.Value;
                        i.Value = j.Value;
                        j.Value = temp;
                        i = i.Next;
                    }
                    j = j.Next;
                }

                // 将基准值放到正确的位置（i节点后面）
                T tempPivot = i.Value;
                i.Value = pivot;
                end.Value = tempPivot;

                // 对基准值左边的子链表进行排序
                QuickSort(list, comparer, start, i.Previous);
                // 对基准值右边的子链表进行排序
                QuickSort(list, comparer, i.Next, end);
            }
        }

        /// <summary>
        /// 使用归并排序进行排序
        /// </summary>
        /// <param name="self"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        public static void Sort<T>([NotNull] this LinkedList<T> self, [NotNull] Comparer<T> comparer)
        {
            if(self.Count <= 1)
            {
                return;
            }

            LinkedList<T> leftHalf = new LinkedList<T>();
            LinkedList<T> rightHalf = new LinkedList<T>();

            // 均匀分割链表为两部分
            SplitLinkedList(self, leftHalf, rightHalf);

            // 递归地对左右子链表进行排序
            Sort(leftHalf, comparer);
            Sort(rightHalf, comparer);

            // 合并已排序的左右子链表回原链表
            MergeLinkedLists(leftHalf, rightHalf, self, comparer);
        }

        /// <summary>
        /// 将链表均匀分割为两部分
        /// </summary>
        /// <param name="source"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <typeparam name="T"></typeparam>
        private static void SplitLinkedList<T>(LinkedList<T> source, LinkedList<T> left, LinkedList<T> right)
        {
            int middle = source.Count / 2;
            LinkedListNode<T> current = source.First;
            for(int i = 0; i < middle; i++)
            {
                left.AddLast(current.Value);
                current = current.Next;
            }
            while (current != null)
            {
                right.AddLast(current.Value);
                current = current.Next;
            }
        }

        /// <summary>
        /// 将两个已排序的链表合并为一个链表
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        private static void MergeLinkedLists<T>(LinkedList<T> left, LinkedList<T> right, LinkedList<T> result, Comparer<T> comparer)
        {
            LinkedListNode<T> leftNode = left.First;
            LinkedListNode<T> rightNode = right.First;
            result.Clear();

            while (leftNode != null && rightNode != null)
            {
                if(comparer.Compare(leftNode.Value, rightNode.Value) <= 0)
                {
                    result.AddLast(leftNode.Value);
                    leftNode = leftNode.Next;
                }
                else
                {
                    result.AddLast(rightNode.Value);
                    rightNode = rightNode.Next;
                }
            }

            while (leftNode != null)
            {
                result.AddLast(leftNode.Value);
                leftNode = leftNode.Next;
            }

            while (rightNode != null)
            {
                result.AddLast(rightNode.Value);
                rightNode = rightNode.Next;
            }
        }

        #endregion
    }
}