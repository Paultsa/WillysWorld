using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour {

    
    public int healthToGive;
    public Object healObject;
    HealthManager hm = new HealthManager();


    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            hm = FindObjectOfType<HealthManager>();
            if (hm.currentHealth < hm.maxHealth)
            {
                
                hm.HealPlayer(healthToGive);
                

                
                //    gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();

                gameObject.SetActive(false);
            }
        }
    }
}
