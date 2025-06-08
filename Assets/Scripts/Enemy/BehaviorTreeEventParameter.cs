using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreeEventParameter
{

    public NodeStateEnum desiredState;
    public Vector3 target;

    public BehaviorTreeEventParameter() { }

    public BehaviorTreeEventParameter(NodeStateEnum desiredState, Vector3 target)
    {
        this.desiredState = desiredState;
        this.target = target;
    }
}
