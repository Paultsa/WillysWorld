using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    public PlayerController thePlayer;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRenderer;
    private float flashCounter;
    public float flashLenght = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

    public GameObject deathEffect;
    public Image blackScreen;
    private bool isFadeToBlack;
    private bool isFadeFromBlack;
    public float fadeSpeed;
    public float waitForFade;
    public GameObject bridge;

    public Text healthLeft;

    private GameManager gm;

    private Checkpoint[] checkpoints;
    

    MenuController menu;

    public AudioSource deathSound;
    public AudioSource backgroundMusic;
    public AudioSource hurtSound;
    public AudioSource healSound;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        healthLeft.text = "x " + currentHealth;
        

        // thePlayer = FindObjectOfType<PlayerController>();

        respawnPoint = thePlayer.transform.position;
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
       if (Time.deltaTime == 0)
        {
            backgroundMusic.Pause();
            deathSound.Pause();
        } else
        {
            backgroundMusic.UnPause();
            deathSound.UnPause();
        }
            if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLenght;
            }

            if (invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }

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
       /* if (Input.GetKey("r"))
        {
            Respawn();
         } */
    }
   

    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invincibilityCounter <= 0)
        {

            currentHealth -= damage;
            healthLeft.text = "x " + currentHealth;
            if (currentHealth > 0)
            {
                hurtSound.Play();
            }

            if (currentHealth <= 0)
            {
                Respawn();
            }
            else
            {

                thePlayer.Knockback(direction);

                invincibilityCounter = invincibilityLength;

                playerRenderer.enabled = false;

                flashCounter = flashLenght;
            }
        }
    }
    public void JumpPlayer(Vector3 direction, JumpPad go)
    {
        thePlayer.Jump(direction, go);
    }


    public void Respawn()
    {
        // thePlayer.transform.position = respawnPoint;
        // currentHealth = maxHealth;

        if (!isRespawning)
        {
            checkpoints = FindObjectsOfType<Checkpoint>();
            foreach (Checkpoint cp in checkpoints)
            {
                cp.setCheck(respawnPoint);
            }
            StartCoroutine("RespawnCo");
            
        }
    }
    
    public IEnumerator RespawnCo()
    {
        
        backgroundMusic.Stop();
        deathSound.Play();
        isRespawning = true;
        thePlayer.gameObject.SetActive(false);
        Instantiate(deathEffect, thePlayer.transform.position, thePlayer.transform.rotation);

        yield return new WaitForSeconds(respawnLength);

        isFadeToBlack = true;

        yield return new WaitForSeconds(waitForFade);

        isFadeToBlack = false;
        isFadeFromBlack = true;

        isRespawning = false;

        
        thePlayer.transform.position = respawnPoint;
        currentHealth = maxHealth;
        healthLeft.text = "x " + currentHealth;

        invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        flashCounter = flashLenght;
        backgroundMusic.Play();

        GoldPickup[] goldPickups = Resources.FindObjectsOfTypeAll<GoldPickup>();
        foreach (GoldPickup gp in goldPickups)
        {
            //objectRespawn(gp.gameObject);
            gp.gameObject.SetActive(true);
            Debug.Log("asdasd");
        }


        KeyBehavior[] keyBehaviors = Resources.FindObjectsOfTypeAll<KeyBehavior>();
        foreach (KeyBehavior kb in keyBehaviors)
        {
            kb.gameObject.SetActive(true);
        }

        NextRoom[] blackBox = Resources.FindObjectsOfTypeAll<NextRoom>();
        foreach (NextRoom nr in blackBox)
        {
            nr.gameObject.SetActive(true);
        }

        bridge.SetActive(false);

        HealPlayer[] healthPickup = Resources.FindObjectsOfTypeAll<HealPlayer>();
        foreach (HealPlayer hp in healthPickup)
        {

            hp.gameObject.SetActive(true);
            //Debug.Log("asdasd");
        }

        gm.setCurrentGold();
        gm.currentGold = 0;
        gm.goldText.text = "x " + gm.currentGold;
        thePlayer.gameObject.SetActive(true);
    }


    public void HealPlayer(int healAmount)
    {


        if (currentHealth < maxHealth)
        {
            healSound.Play();
            currentHealth += healAmount;
            healthLeft.text = "x " + currentHealth;

        }
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
    public void objectRespawn(GameObject go)
    {
        go.SetActive(true);
    }

}
