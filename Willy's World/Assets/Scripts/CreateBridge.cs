using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBridge : MonoBehaviour {
    public GameObject bridge;
	
	void Start () {
		
	}
	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bridge.gameObject.SetActive(true);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
