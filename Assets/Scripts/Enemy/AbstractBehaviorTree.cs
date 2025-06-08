using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBehaviorTree : MonoBehaviour
{
    /// <summary>
    /// the list of the behaviorTree nodes
    /// </summary>
    public List<GenericNode> nodes = new List<GenericNode>();



    protected void Start()
    {
    }

    /// <summary>
    /// the desired next state
    /// </summary>
    /// <param name="desiredNextState"></param>
    public abstract void execute(NodeStateEnum desiredState);
    
}



