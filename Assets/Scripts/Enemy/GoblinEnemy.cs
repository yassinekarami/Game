using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemy : Enemy
{

    BehaviorTree behaviorTree;
    BehaviorTreeEventParameter parametreEventParameter;

    void Start()
    {
        base.Start();
        behaviorTree = GetComponent<BehaviorTree>();
    }

    void Update()
    {
        if (player != null)
        {
            if (isPlayerDetected())
            {
                Debug.Log("player detected");
                if (behaviorTree.transitions.TryGetValue(behaviorTree.currentState, 
                    out behaviorTree.potentialStates) && behaviorTree.potentialStates.Contains(NodeStateEnum.CHASE))
                {
                    Debug.Log("transition possible");

                    parametreEventParameter =
                        new BehaviorTreeEventParameter(NodeStateEnum.CHASE, player.transform.position);

                    behaviorTree.currentState = NodeStateEnum.CHASE;


                }
            }
            else if (isPlayerInAttackRange())
            {
                Debug.Log("player in attack range");
                if (behaviorTree.transitions.TryGetValue(behaviorTree.currentState,
                    out behaviorTree.potentialStates) && behaviorTree.potentialStates.Contains(NodeStateEnum.ATTACK))
                {
                    Debug.Log("transition possible");

                    parametreEventParameter =
                        new BehaviorTreeEventParameter(NodeStateEnum.ATTACK, player.transform.position);

                    behaviorTree.currentState = NodeStateEnum.ATTACK;

                }
            }
            else
            {
                Debug.Log("idle");
                if (behaviorTree.transitions.TryGetValue(behaviorTree.currentState,
                    out behaviorTree.potentialStates) && behaviorTree.potentialStates.Contains(NodeStateEnum.IDLE))
                {
                    Debug.Log("transition possible");

                    parametreEventParameter =
                        new BehaviorTreeEventParameter(NodeStateEnum.IDLE, player.transform.position);

                    behaviorTree.currentState = NodeStateEnum.IDLE;

                }
            }

            behaviorTree?.execute(parametreEventParameter);

        }

    }
}
