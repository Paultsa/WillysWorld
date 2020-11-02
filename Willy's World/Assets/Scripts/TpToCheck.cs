using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpToCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(FindObjectOfType<HealthManager>().currentHealth);
        if (other.tag == "Player" && FindObjectOfType<HealthManager>().currentHealth > 0)
        {
                FindObjectOfType<Checkpoint>().playerToCheck();
        }
    }
}
