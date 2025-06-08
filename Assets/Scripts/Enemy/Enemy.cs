using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    protected static GameObject player;
    public int detectRange = 0;
    public int attackRange = 0;


    // Start is called before the first frame update
    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected Boolean isPlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= attackRange &&
            Vector3.Distance(transform.position, player.transform.position) > detectRange;
    }

    protected Boolean isPlayerDetected()
    {

        return Vector3.Distance(transform.position, player.transform.position) <= detectRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
