using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int currentGold;
    public Text goldText;
    private int savedGold;

    public AudioSource coinSound;


	// Use this for initialization
	void Start () {
        CharacterData cd = SaveLoadManger.LoadCharacter(1);

        if (cd.getLevelId() != 2)
        {
            Debug.Log("1111");
            savedGold = cd.getGoldCount();
            setCurrentGold();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddGold(int goldToAdd)
    {
        coinSound.Play();
        currentGold += goldToAdd;
        goldText.text = "x " + currentGold;
    }

    public void saveCurrentGold()
    {
        savedGold = currentGold;
    }

    public void setCurrentGold()
    {
        currentGold = savedGold;
        goldText.text = "x " + currentGold;
    }

    public int getCurrentGold()
    {
        return currentGold;
    }
}
