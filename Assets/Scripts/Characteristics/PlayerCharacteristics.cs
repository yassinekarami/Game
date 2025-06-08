using UnityEngine;
using UnityEngine.Events;

/**
 *  class for playerCharacteristics
 */
public class PlayerCharacteristics : AbstractCharacteristics
{

    private float currenthealth;

    public UpdateUIEvent updateUI = new UpdateUIEvent();
    public UnityEvent launchDieAnimation;

    



    private void Start()
    {
        currenthealth = characteristics.maxHealth;
      
    }

    /// <summary>
    /// decrease currentHealth by healthToRemove
    /// </summary>
    /// <param name="healthToRemove">health to remove</param>
    public override void decreaseHealth(float healthToRemove)
    {
        if (currenthealth > 0)
        {
            this.currenthealth -= healthToRemove;
            updateUI?.Invoke(this.currenthealth);

            if (currenthealth == 0)
            {
                launchDieAnimation?.Invoke();
            }
        }
    }
}
