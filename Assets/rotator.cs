using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour {
    public float objectVerticalAngle;
    public float objectAngle;
    public float maxRotation;
    public float speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.rotation = Quaternion.Euler(objectVerticalAngle, objectAngle + maxRotation * Mathf.Sin(Time.time * speed), 0f);
    }
}
