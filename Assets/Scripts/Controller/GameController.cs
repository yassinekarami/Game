using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * the game controller listen to event involving interaction between multiple gameobjects
 * and the trigger the action on the target depending on the source
 */
public class GameController : MonoBehaviour
{
    GameObject[] enemies = new GameObject[1000];
    GameObject player;
    public WeaponController weaponController;

 
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        weaponController.hasBeenAttackedEvent += hasBeenAttacked;
   
    }


    /// <summary>
    /// tells that g1 is attacking g2
    /// </summary>
    /// <param name="source">the source</param>
    /// <param name="target">the target</param>
    public void hasBeenAttacked(GameObject source, GameObject target)
    {
        this.decreaseHealth(source, target);

    }

    private void decreaseHealth(GameObject source, GameObject target)
    { 
        if (source.GetComponent<GoblinCharacteristics>() != null)
        {
            int damages = source.GetComponent<GoblinCharacteristics>().characteristics.dammages;
            target.GetComponent<PlayerCharacteristics>()?.decreaseHealth(damages);
        } 
        else if (source.GetComponent<PlayerCharacteristics>() != null)
        {
            int damages = source.GetComponent<PlayerCharacteristics>().characteristics.dammages;
            target.GetComponent<GoblinCharacteristics>()?.decreaseHealth(damages);
        }
    }

}
