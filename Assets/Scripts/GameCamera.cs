using UnityEngine;
using System.Collections;

/*Camera script from this tutorial
https://www.youtube.com/watch?v=pSN2x3dPgYw
*/

public class GameCamera : MonoBehaviour
{
    private Vector3 camTgt;
    public Transform target;
	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        camTgt = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = Vector3.Lerp(transform.position, camTgt, Time.deltaTime * 8);

    }
}
