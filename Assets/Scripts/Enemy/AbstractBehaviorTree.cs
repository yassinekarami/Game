using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class AbstractBehaviorTree : MonoBehaviour
{
    /// <summary>
    /// the list of the behaviorTree nodes
    /// </summary>
    public List<GenericNode> nodes = new List<GenericNode>();

    /// <summary>
    /// nav mesh agent
    /// </summary>
    private NavMeshAgent agent;

    /// <summary>
    /// animator
    /// </summary>
    private Animator animator;


    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// the desired next state
    /// </summary>
    /// <param name="desiredNextState"></param>
    public abstract void execute(BehaviorTreeEventParameter parameters);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="target"></param>
    /// <returns>return an UnityAction</returns>
    protected UnityAction goToTarget(Vector3 target)
    {
        Debug.Log("go to target");
        return () =>
        {
            if (agent != null && target != null)
            {
                agent.SetDestination(target);
            }
        };
       
    }

    /// <summary>
    /// make the animator execute the animation
    /// </summary>
    /// <param name="name"></param>
    /// <returns>return an UnityAction</returns> 
    public UnityAction launchAnimation(string name)
    {
        Debug.Log("launch Animation");
        return () =>
        {
            animator.SetBool(name, true);
        };
    }
    
}



