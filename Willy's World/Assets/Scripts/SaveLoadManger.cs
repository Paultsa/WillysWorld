using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Save tapahtuu kun hahmo astuu teleporttiin joka vie seuraavaan leveliin
 * Asiat jotka tallentuu: goldit, seuraavan levelin aloituspiste
 * Loadaaminen taas tapahtuu kun pelaaja valitsee main menusta "Continue"
 */
public class SaveLoadManger : MonoBehaviour {

    public CharacterData characterData;

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.S))
            SaveCharacter(characterData, 0);

        if (Input.GetKeyDown(KeyCode.L))
            characterData = LoadCharacter(0);
        */
    }

    public static void SaveCharacter(CharacterData data, int characterSlot)
    {
        //data.goldCount++;
        //PlayerPrefs.SetString("characterName_CharacterSlot" + characterSlot, data.characterName);
        PlayerPrefs.SetInt("goldCount_CharacterSlot" + characterSlot, data.goldCount);
        PlayerPrefs.SetInt("levelId_CharacterSlot" + characterSlot, data.levelId);
        PlayerPrefs.Save();
        Debug.Log(data.getGoldCount());
    }

    public static CharacterData LoadCharacter(int characterSlot)
    {
        CharacterData loadedCharacter = new CharacterData();
        //loadedCharacter.characterName = PlayerPrefs.GetString("characterName_CharacterSlot" + characterSlot);
        loadedCharacter.goldCount = PlayerPrefs.GetInt("goldCount_CharacterSlot" + characterSlot);
        loadedCharacter.levelId = PlayerPrefs.GetInt("levelId_CharacterSlot" + characterSlot);

        //Debug.Log(loadedCharacter.getGoldCount());
        return loadedCharacter;
    }
}
