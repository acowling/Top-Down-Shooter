using UnityEngine;
using System.Collections;
/* Movt script based on this tutorial
https://www.youtube.com/watch?v=pSN2x3dPgYw
Weapon firing script based on this tutorial
https://www.youtube.com/watch?v=7RtyA8j-_-E
*/
[RequireComponent (typeof (CharacterController))]

public class PlyrMvt : MonoBehaviour
{
    //
    private Quaternion tgtRot;
    //Components
    public WpnCtrl gun;
    private CharacterController controller;
    private Camera cam;
    //Handling
    public float rotSpeed = 450.0f;
    public float walkSpeed = 5.0f;
    public float runSpeed = 8.0f;

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Movt();
        Aiming();

        if (Input.GetButtonDown("Fire"))
        {
            gun.Shoot();
        }
        else if (Input.GetButton("Fire"))//Checks that the player is holding the fire button, if they have a Auto weapon it will fire
        {
            gun.AutoFire();
        }
    }

    void Movt()//Movement is done with WASD
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
        motion += Vector3.up * -8;
        controller.Move(motion * Time.deltaTime);
    }

    void Aiming()//Aiming is done with the mouse cursor
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
        tgtRot = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x,0,transform.position.z));
        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, tgtRot.eulerAngles.y, rotSpeed * Time.deltaTime);

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 motion = input;
        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? 0.7f : 1;
        motion *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;
        motion += Vector3.up * -8;
        controller.Move(motion * Time.deltaTime);
    }
}
