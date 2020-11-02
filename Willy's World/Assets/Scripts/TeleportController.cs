using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeleportController : MonoBehaviour {

    public CharacterData characterData;

    private bool isFadeToBlack;
    private bool isFadeFromBlack;
    public Image blackScreen;
    public float fadeSpeed;
    public float waitForFade;
    public float displayText;
	// Use this for initialization
	void Start () {
        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, 1f);

        isFadeFromBlack = true;
	}


	
	// Update is called once per frame
	void Update () {
        if (isFadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 1f)
            {
                isFadeToBlack = false;
            }
        }


        if (isFadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                isFadeFromBlack = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Save();
            StartCoroutine("TeleportCo");
        }
    }

    IEnumerator TeleportCo()
    {
        
        yield return new WaitForSeconds(displayText);

        isFadeToBlack = true;

        yield return new WaitForSeconds(waitForFade);

        isFadeToBlack = false;
        isFadeFromBlack = true;

        FindObjectOfType<LevelManager>().LoadNextScene();
    }

    public void Save()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int goldCount = FindObjectOfType<GameManager>().getCurrentGold();
        characterData.setGoldCount(goldCount);
        characterData.setLevelId(nextSceneIndex);
        SaveLoadManger.SaveCharacter(characterData, 1);
    }
}
