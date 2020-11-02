using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpingForce;
    public AudioSource aanenMuokkaus;



    // Use this for initialization
    void Start()
    {
        aanenMuokkaus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
  
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            aanenMuokkaus.Play();
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;

            FindObjectOfType<HealthManager>().JumpPlayer(hitDirection, this);


        }
    }
}
