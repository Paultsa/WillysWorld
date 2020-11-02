using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private HealthManager HealthMan;
    

  //  public Renderer theRend;

  //  public Material cpOff;
   // public Material cpOn;

    private Vector3 check;

  

    public ParticleSystem ps;
    

    

	// Use this for initialization
	void Start () {
        
        FindObjectOfType<GameManager>().saveCurrentGold();
        check = FindObjectOfType<PlayerController>().transform.position;
        //  theRend.material = cpOff;
        ps.Stop();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach (Checkpoint cp in checkpoints)
        {
            cp.CheckpointOff(this);
        }


        //theRend.material = cpOn;
        ps.Play();
    }

    public void CheckpointOff(Checkpoint checkP)
    {

       // theRend.material = cpOff;
        ps.Stop();
        check = checkP.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Check");
            check = other.gameObject.transform.position;
            FindObjectOfType<GameManager>().saveCurrentGold();
            CheckpointOn();
        }
    }
    public void playerToCheck()
    {
        FindObjectOfType<PlayerController>().transform.position = check;
    }
    public void setCheck(Vector3 newCheck)
    {
        CheckpointOff(this);
        check = newCheck;
        
    }
}
