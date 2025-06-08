
using UnityEngine;

/// <summary>
/// the class responsible of triggering the animations for the player
/// </summary>
public class PlayerAnimations : AbstractAnimations
{
    /// <summary>
    /// set the animator attack parameter value
    /// </summary>
    public override void setAtttack()
    {
        animator.SetInteger("attack", UnityEngine.Random.Range(1, 3));
    }

    /// <summary>
    /// set the animator defend parameter value
    /// </summary>
    /// <param name="value"></param>
    public override void setDefend(bool value)
    {
        this.animator.SetBool("defend", value);
    }

    /// <summary>
    /// set the animator running parameter value
    /// </summary>
    /// <param name="value"> the value to set</param>
    public override void setRunning(Vector3 value)
    {
        this.animator.SetBool("running", value.magnitude.Equals(0) ? false : true);
    }

    /// <summary>
    /// get defend value
    /// </summary>
    /// <returns></returns>
    public override bool getDefend()
    {
        return this.defend;
    }

    /// <summary>
    /// get die value
    /// </summary>
    /// <returns></returns>
    public override bool getDie()
    {
        return this.die;
    }

    /// <summary>
    /// get the running value
    /// </summary>
    /// <returns></returns>
    public override Vector3 getRunning()
    {
        return this.running;
    }

    /// <summary>
    /// set the die trigger
    /// </summary>
    /// <param name="value"></param>
    public override void setDie(bool value)
    {
        this.animator.SetTrigger("die");
    }

    public override void setRunning()
    {
        throw new System.NotImplementedException();
    }
}
