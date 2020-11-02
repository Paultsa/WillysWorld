using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {
    public GameObject menu;
    private CameraFollow cc;
	// Use this for initialization
    
	void Start () {
        menu.SetActive(false);
        cc = FindObjectOfType<CameraFollow>();
        ContinueGame();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            menu.SetActive(true);
         //   cc.FreezeCam();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }

    public void ContinueGame()
    {
        menu.SetActive(false);
       //cc.UnFreezeCam();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Respawn()
    {
        Debug.Log("Respawn");
        FindObjectOfType<HealthManager>().Respawn();
        ContinueGame();
    }
}
