using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    private CharacterData characterData;

    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;
    public Image text = null;
    public int fadeSpeed;
    public Animator menuAnim;

	// Use this for initialization
	void Start () {
        characterData = SaveLoadManger.LoadCharacter(1);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
	}

    private void Update()
    {
        if (text)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.MoveTowards(text.color.a, 1f, fadeSpeed * Time.deltaTime));
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(characterData.getLevelId());
    }

    public void LoadNewGame()
    {
        characterData = SaveLoadManger.LoadCharacter(1);
        characterData.setGoldCount(0);
        characterData.setLevelId(2);
        SaveLoadManger.SaveCharacter(characterData, 1);
        SceneManager.LoadScene(characterData.getLevelId());
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
