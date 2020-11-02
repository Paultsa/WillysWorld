using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour {

    public int value;

    
    public GameObject pickupEffect;
    // public GameObject goldPickup;
    

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           

            //   gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            
            
            FindObjectOfType<GameManager>().AddGold(value);
           

            //FindObjectOfType<DialogueTrigger>().TriggerDialogue();

            Instantiate(pickupEffect, transform.position, transform.rotation);

            gameObject.SetActive(false);
        }
    }
   
}
