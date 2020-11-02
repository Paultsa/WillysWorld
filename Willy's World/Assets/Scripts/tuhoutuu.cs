using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuhoutuu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

         

                //    gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();

                gameObject.SetActive(false);
            }
        }
    }


