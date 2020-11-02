using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour {
    public float fadeSpeed;
    public Text text;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.MoveTowards(text.color.a, 1f, fadeSpeed * Time.deltaTime));
    }
}
