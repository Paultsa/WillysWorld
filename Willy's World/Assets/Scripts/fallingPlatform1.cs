using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour {
    bool isFalling = false;
    float downSpeed = 0;
    // Use this for initialization

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        isFalling = true;
        transform.position = new Vector3(transform.position.x,
        transform.position.y - downSpeed-downSpeed,
        transform.position.z);
    }
   
		
	
	
	// Update is called once per frame
	void Update () {
		if (isFalling)
        {
            downSpeed += Time.deltaTime/4;
            transform.position = new Vector3(transform.position.x, transform.position.y-downSpeed, transform.position.z);
        }
	}
}
