using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMove : MonoBehaviour {

    public float rotateSpeedZ = 0;
    public float rotateSpeedX = 0;
    public float rotateSpeedY = 0;
	void Start () {
		
	}
	
	void Update () {
        transform.Rotate(new Vector3(rotateSpeedX, rotateSpeedY, rotateSpeedZ) * Time.deltaTime);
	}
}
