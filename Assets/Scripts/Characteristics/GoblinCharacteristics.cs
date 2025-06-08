using UnityEngine;
/**
* class for skeletonCharacteristics
*/
public class GoblinCharacteristics : AbstractCharacteristics
{

    private float currenthealth;



    public override void decreaseHealth(float healthToRemove)
    {
        this.currenthealth = this.currenthealth - healthToRemove;
    }
}
