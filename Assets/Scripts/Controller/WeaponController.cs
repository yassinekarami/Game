using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    /// <summary>
    /// action to be triggred when a character has been attacked
    /// the first parameter is for the source
    /// the second parameter is the target
    /// </summary>
    public event Action<GameObject, GameObject> hasBeenAttackedEvent;

    private void OnTriggerEnter(Collider other)
    {

        if (other != null && other.gameObject.tag.Equals("Enemy"))
        {
            hasBeenAttackedEvent?.Invoke(gameObject, other.gameObject);
        }
    }
}