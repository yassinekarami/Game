using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCharacteristics : MonoBehaviour
{

    public TextAsset file;
    public Characteristics characteristics;
    private void Awake()
    {
        characteristics = this.loadCharacteristics(file.ToString());
    }
    /// <summary>
    /// decrease currentHealth by healthToRemove
    /// </summary>
    /// <param name="healthToRemove">amount of health to remove</param>
    public abstract void decreaseHealth(float healthToRemove);

    /// <summary>
    /// load the characteristics contained in json
    /// </summary>
    /// <param name="json">data to load</param>
    /// <returns>Characteristics instance</returns>
    public Characteristics loadCharacteristics(string json)
    {
        return JsonUtility.FromJson<Characteristics>(json);
    }
}
