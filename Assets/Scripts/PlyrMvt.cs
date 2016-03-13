using UnityEngine;
using System.Collections;
/* Movt script based on this tutorial
https://www.youtube.com/watch?v=pSN2x3dPgYw
*/
[RequireComponent (typeof (CharacterController))]

public class PlyrMvt : MonoBehaviour
{
    //
    private Quaternion tgtRot;
    //Components
    private CharacterController controller;
    //Handling
    public float rotSpeed = 450.0f;
    public float walkSpeed = 5.0f;
    public float runSpeed = 8.0f;

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (input != Vector3.zero)
        {
            tgtRot = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, tgtRot.eulerAngles.y, rotSpeed * Time.deltaTime);
        }

        Vector3 motion = input;
        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? 0.7f : 1;
        motion *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;
        motion += Vector3.up * -8 ;
        controller.Move(motion * Time.deltaTime);
    }
}
