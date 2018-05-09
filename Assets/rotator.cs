using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour {
    public float objectVerticalAngle;
    public float objectAngle;
    public float object2Angle;
    public float maxRotation;
    public float speed;
    public bool route1 = false;
    public bool route2 = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (route1)
        {
            transform.rotation = Quaternion.Euler(objectVerticalAngle, objectAngle + maxRotation * Mathf.Sin(Time.time * speed), 0f);
        }
        
        if (route2)
        {
            transform.rotation = Quaternion.Euler(objectVerticalAngle, object2Angle + maxRotation * Mathf.Sin(Time.time * speed), 0f);
        }
    }
}
