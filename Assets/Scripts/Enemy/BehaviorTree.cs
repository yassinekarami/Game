using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// implementation of the AbstractBehaviorTree
/// </summary>
public class BehaviorTree : AbstractBehaviorTree
{

    
    public override void execute(NodeStateEnum desiredNextState)
    {
        GenericNode nodeToBeExecuted = nodes.Find(n => desiredNextState.Equals(n.getCurrentState()));
        nodeToBeExecuted?.getUnityEvent()?.Invoke();
    }
}
