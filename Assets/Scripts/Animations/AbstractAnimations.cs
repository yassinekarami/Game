using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AbstractAnimations : MonoBehaviour
{

    protected Animator animator;
    protected bool die;
    protected bool defend;
    protected Vector3 running;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }



    public abstract bool getDie();

    public abstract bool getDefend();

    public abstract Vector3 getRunning();

    /**
     * set the animator attack parameter value
     */
    public abstract void setAtttack();

    /**
     * set the animator die parameter value
     */
    public abstract void setDie(bool value);

    /**
     * set the animator defend parameter value
     */
    public abstract void setDefend(bool value);

    /**
     * set the animator running parameter value
     */
    public abstract void setRunning(Vector3 value);

    /**
 * set the animator running parameter value
 */
    public abstract void setRunning();

}
