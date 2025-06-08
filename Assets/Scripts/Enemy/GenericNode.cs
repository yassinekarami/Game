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
    public UnityAction action;

  

    /// <summary>
    /// default constructor for Generic Node class
    /// </summary>
    public GenericNode(){}

    /// <summary>
    /// constructor for Generic Node class
    /// </summary>
    /// <param name="currentState"></param>
    /// <param name="action"></param>
    public GenericNode(NodeStateEnum currentState,UnityAction action)
    {
        this.currentState = currentState;
        this.action = action;
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


    public UnityAction getUnityAction() { return this.action; }


}
