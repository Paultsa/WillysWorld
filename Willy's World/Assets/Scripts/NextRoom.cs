using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoom : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
       

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DestroyGameObjectWithTag(tag);
        }
    }
         void DestroyGameObjectWithTag(string tag)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject DestroyObject in gameObjects)
            {
            DestroyObject.gameObject.SetActive(false);
              //  Destroy(DestroyObject);
            }
        }

    }
 

  