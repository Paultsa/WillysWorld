using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hauskaPlatform : MonoBehaviour
{
    bool isFalling = false;
    float downSpeed = 0;
    public float suunta;
    // Use this for initialization
    private Vector3 startPosition;
    public float waitTime;
    public float moveSpeed = 0;
    public GameObject player;



    private void Start()
    {
        startPosition = transform.position;
        Debug.Log(startPosition);


    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
            isFalling = true;
        transform.position = new Vector3(transform.position.x,
        transform.position.y + downSpeed,
        transform.position.z);
        player.transform.parent = transform;
        StartCoroutine("RespawnCo");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.parent = null;
            player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(waitTime);
        if (player.transform.parent == transform)
        {
            player.transform.parent = null;
            player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        isFalling = false;
        transform.position = startPosition;
        downSpeed = 0;

    }




    // Update is called once per frame
    void Update()
    {
        if (isFalling && Time.timeScale != 0)
        {
            downSpeed += Time.deltaTime / moveSpeed;
            Debug.Log(downSpeed);
            Debug.Log(Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y + downSpeed * suunta, transform.position.z);
        }
    }
}