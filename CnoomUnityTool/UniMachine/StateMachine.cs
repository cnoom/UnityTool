﻿using System;
using System.Collections.Generic;
using CnoomUnityTool.BaseUtil;

// ReSharper disable CheckNamespace
namespace CnoomUnityTool.UniMachine
{
    public class StateMachine
    {
        private readonly Dictionary<string, object> _blackboard = new Dictionary<string, object>(100);
        private readonly Dictionary<string, IStateNode> _nodes = new Dictionary<string, IStateNode>(100);
        private IStateNode _curNode;
        private IStateNode _preNode;
        /// <summary>
        /// 转换节点时是否存在输出
        /// </summary>
        public bool HasLog = true;
        private StateMachine() { }
        public StateMachine(object owner)
        {
            Owner = owner;
        }

        /// <summary>
        ///     状态机持有者
        /// </summary>
        public object Owner { private set; get; }

        /// <summary>
        ///     当前运行的节点名称
        /// </summary>
        public string CurrentNode => _curNode != null ? _curNode.GetType().FullName : string.Empty;

        /// <summary>
        ///     之前运行的节点名称
        /// </summary>
        public string PreviousNode => _preNode != null ? _preNode.GetType().FullName : string.Empty;

        /// <summary>
        ///     更新状态机
        /// </summary>
        public void Update()
        {
            if(_curNode != null)
                _curNode.OnUpdate();
        }

        /// <summary>
        ///     启动状态机
        /// </summary>
        public void Run<TNode>() where TNode : IStateNode
        {
            Type nodeType = typeof(TNode);
            string nodeName = nodeType.FullName;
            Run(nodeName);
        }
        public void Run(Type entryNode)
        {
            string nodeName = entryNode.FullName;
            Run(nodeName);
        }
        public void Run(string entryNode)
        {
            _curNode = TryGetNode(entryNode);
            _preNode = _curNode;

            if(_curNode == null)
                throw new Exception($"Not found entry node: {entryNode}");

            _curNode.OnEnter();
        }

        /// <summary>
        ///     加入一个节点
        /// </summary>
        public void AddNode<TNode>() where TNode : IStateNode
        {
            Type nodeType = typeof(TNode);
            IStateNode stateNode = Activator.CreateInstance(nodeType) as IStateNode;
            AddNode(stateNode);
        }
        public void AddNode(IStateNode stateNode)
        {
            if(stateNode == null)
                throw new ArgumentNullException();

            Type nodeType = stateNode.GetType();
            string nodeName = nodeType.FullName;

            if(_nodes.ContainsKey(nodeName) == false)
            {
                stateNode.OnCreate(this);
                _nodes.Add(nodeName, stateNode);
            }
            else
            {
                LogUtil.Log<StateMachine>($"State node already existed : {nodeName}", LogLevel.Error);
            }
        }

        /// <summary>
        ///     转换状态节点
        /// </summary>
        public void ChangeState<TNode>() where TNode : IStateNode
        {
            Type nodeType = typeof(TNode);
            string nodeName = nodeType.FullName;
            ChangeState(nodeName);
        }
        public void ChangeState(Type nodeType)
        {
            string nodeName = nodeType.FullName;
            ChangeState(nodeName);
        }
        public void ChangeState(string nodeName)
        {
            if(string.IsNullOrEmpty(nodeName))
                throw new ArgumentNullException();

            IStateNode node = TryGetNode(nodeName);
            if(node == null)
            {
                LogUtil.Log<StateMachine>($"Can not found state node : {nodeName}", LogLevel.Error);
                return;
            }
            if(HasLog) LogUtil.Log<StateMachine>($"{_curNode.GetType().FullName} ---> {node.GetType().FullName}");
            _preNode = _curNode;
            _curNode.OnExit();
            _curNode = node;
            _curNode.OnEnter();
        }

        /// <summary>
        ///     设置黑板数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetBlackboardValue(string key, object value)
        {
            if(_blackboard.ContainsKey(key) == false)
                _blackboard.Add(key, value);
            else
                _blackboard[key] = value;
        }

        /// <summary>
        ///     获取黑板数据
        /// </summary>
        public object GetBlackboardValue(string key)
        {
            if(_blackboard.TryGetValue(key, out object value))
            {
                return value;
            }
            LogUtil.Log<StateMachine>($"Not found blackboard value : {key}", LogLevel.Error);
            return null;
        }

        private IStateNode TryGetNode(string nodeName)
        {
            _nodes.TryGetValue(nodeName, out IStateNode result);
            return result;
        }
    }
}