using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

/// <summary>
/// implementation of the AbstractBehaviorTree
/// </summary>
public class BehaviorTree : AbstractBehaviorTree
{
    public IDictionary<NodeStateEnum, List<NodeStateEnum>> transitions = new Dictionary<NodeStateEnum, List<NodeStateEnum>>();

    public NodeStateEnum currentState;
    public List<NodeStateEnum> potentialStates;

    private void Start()
    {
        base.Start();

        currentState = NodeStateEnum.IDLE;
        // set up transition list
        transitions.Add(NodeStateEnum.IDLE, new List<NodeStateEnum> { NodeStateEnum.CHASE });
        transitions.Add(NodeStateEnum.CHASE, new List<NodeStateEnum> { NodeStateEnum.IDLE, NodeStateEnum.ATTACK });
        transitions.Add(NodeStateEnum.ATTACK, new List<NodeStateEnum> { NodeStateEnum.CHASE });
    }
    public override void execute(BehaviorTreeEventParameter parameter)
    {
        if (parameter != null)
        {
            GenericNode nodeToBeExecuted = nodes.Find(n => parameter.desiredState.Equals(n.getCurrentState()));
            UnityAction actionToBeExecuted = nodeToBeExecuted.getUnityAction();

            actionToBeExecuted += goToTarget(parameter.target);
            actionToBeExecuted += this.launchAnimation(nodeToBeExecuted.getCurrentState().ToString());
            actionToBeExecuted.Invoke();
        }

    }
}
