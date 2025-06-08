using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float rotationSpeed = 50;
    private float cameraHorizontal;
    
    public float moveSpeed = 50;
    private float moveHorizontal;
    private float moveVertical;

    /**
     * event for defend action
     */
    public DefendEvent defendEvent = new DefendEvent();
    /**
     * event for attack action
     */
    public AttackEvent attackEvent = new AttackEvent();
    /**
     * event for moving action
     */
    public MoveEvent moveEvent = new MoveEvent();

    /**
     * gameobject's rigidbody
     */
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        cameraHorizontal = Input.GetAxis("Mouse Y");
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");


        // apply the rotation to rigidbody transform
        rb.transform.transform.Rotate(this.rotate(cameraHorizontal) * Time.fixedDeltaTime * rotationSpeed);
        // modifie the rigidbody's velocity
        rb.velocity = move(moveVertical, moveHorizontal) * Time.fixedDeltaTime * moveSpeed;
        moveEvent?.Invoke(rb.velocity);

        defendEvent?.Invoke(Input.GetMouseButton(1));

        if (Input.GetMouseButtonDown(0))
        {
            attackEvent?.Invoke(Input.GetMouseButtonDown(0));
        }
    }

    /**
     * create a new vector with the values of Horizontal Axis and Vertical Axis
     * @param moveVertical the value of vertical axis
     * @param moveHorizontal the value of horizontal axis
     * 
     * return a new vector with the values of vertical and horizontal axis
     */
    private Vector3 move(float moveVertical, float moveHorizontal)
    {
        return new Vector3(moveVertical, 0, moveHorizontal);
    }
    /**
     * rotate the gameObject
     * @param horizontal value
     * 
     * return the rotation vector3
     */
    private Vector3 rotate(float horizontal)
    {
        // start point rotation
        Quaternion quatStart = new Quaternion(0, 0, 0, 1);
        // end point rotation
        Quaternion quatEnd = new Quaternion(0, horizontal, 0, 1);
        // interpolation between rotation start and rotation end
        // and convert it to vector3
        return Quaternion.Lerp(quatStart, quatEnd, 1).eulerAngles;   
    }

    /**
     * Draw Gizmos
     */
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(0,0,0), new Vector3(1,0,0));
        Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(1, 0, 1));
        Gizmos.color = Color.gray;
       
        Vector3 vectDiff = Quaternion.FromToRotation(new Vector3(1, 0, 1), new Vector3(1, 0, 0)).eulerAngles;
        Gizmos.DrawLine(new Vector3(0, 0, 0), vectDiff);

        Gizmos.color = Color.green; 
  
        Quaternion quatStart = new Quaternion(0, 0, 0, 1);
        Quaternion quatEnd = new Quaternion(cameraHorizontal, 0, 0, 1);  
    }
}
