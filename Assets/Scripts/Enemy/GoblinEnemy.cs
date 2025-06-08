using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemy : Enemy
{
    private IDictionary<NodeStateEnum, NodeStateEnum> transitions = new Dictionary<NodeStateEnum, NodeStateEnum>();

    private NodeStateEnum currentState;
    private NodeStateEnum newState;
    void Start()
    {
        currentState = NodeStateEnum.IDLE;
        // set up transition list
        transitions.Add(NodeStateEnum.IDLE, NodeStateEnum.CHASE);
        transitions.Add(NodeStateEnum.CHASE, NodeStateEnum.ATTACK);
        transitions.Add(NodeStateEnum.ATTACK, NodeStateEnum.CHASE);

    }

    void Update()
    {
        if (player != null)
        {
            if (isPlayerDetected())
            {
                Debug.Log("player detected");
                if (transitions.TryGetValue(currentState, out newState) && newState.Equals(NodeStateEnum.CHASE))
                {
                    Debug.Log("transition possible");
                    GetComponent<BehaviorTree>()?.execute(currentState);
                    currentState = newState;

                } else
                {
                    Debug.Log("transition impossible");
                    return;
                }
                
                
            }
            else if (isPlayerInAttackRange())
            {
                Debug.Log("player in attack range");
                // send an event to behaviortree to update the state
                //      behaviorTreeUpdateEvent?.Invoke(NodeStateEnum.ATTACK);
            }
            else
            {
                Debug.Log("idle");
                //    behaviorTreeUpdateEvent?.Invoke(NodeStateEnum.IDLE);
            }
          
        }

    }
}
