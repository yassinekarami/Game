using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Class for custom making and receiving damage event
 * @param the event sender
 * @param the event receiver
 */
[System.Serializable]
public class DamageEvent : UnityEvent<GameObject>
{

}
