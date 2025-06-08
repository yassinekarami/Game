using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// the class reprensent a GenericNode in the behavior tree
/// </summary>
[System.Serializable]
public class GenericNode
{
    /// <summary>
    /// the state of  Node ( IDLE , WALK )
    /// </summary>
    public NodeStateEnum currentState;

    /// <summary>
    /// the action to be executed when the node is in success mode
    /// </summary>
    public UnityEvent action; 

  

    /// <summary>
    /// default constructor for Node class
    /// </summary>
    public GenericNode(){}

    public GenericNode(NodeStateEnum currentState, StateStatusEnum stateStatus, UnityEvent action)
    {
        this.currentState = currentState;
        this.action = action;
    }



    /// <summary>
    /// constructor for Node class
    /// </summary>
    /// <param name="state">the initial state</param>
    /// <param name="action">the action to be executed when the node is in success mode</param>
    public GenericNode(NodeStateEnum currentState, UnityAction action)
    {
        this.currentState = currentState;
      //  this.action = action;
    }

        

    /// <summary>
    /// get the current state
    /// </summary>
    /// <returns>the state of the node</returns>
    public NodeStateEnum getCurrentState() { return currentState; }

    /// <summary>
    /// set the current state of the node
    /// </summary>
    /// <param name="state">the new state</param>
    public void setCurrentState(NodeStateEnum state) { this.currentState = state; }


    public UnityEvent getUnityEvent() { return this.action; }


}
