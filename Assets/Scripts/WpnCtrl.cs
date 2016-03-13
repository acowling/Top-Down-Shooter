using UnityEngine;
using System.Collections;
/* WpnCtrl script taken from
https://www.youtube.com/watch?v=7RtyA8j-_-E
*/
public class WpnCtrl : MonoBehaviour
{
    public enum WpnType {Auto,Burst,Semi}
    public WpnType wpnType;
    public Transform bulletSpawn;
    public float maxShotRange = 20.0f;

	// Use this for initialization
	void Start ()
    {
	
	}

    public void Shoot()
    {
        Ray ray = new Ray(bulletSpawn.position, bulletSpawn.forward);
        RaycastHit hit;
        float shotDist = maxShotRange;
        if (Physics.Raycast(ray, out hit, shotDist))
        {
            shotDist = hit.distance;
        }
        Debug.DrawRay(ray.origin, ray.direction * shotDist, Color.red, 1);
    }

    public void AutoFire()
    {
        if (wpnType == WpnType.Auto)
        {
            Shoot();
        }
    }
}
