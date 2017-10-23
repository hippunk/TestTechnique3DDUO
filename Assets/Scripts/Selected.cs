using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour {

	public Color selectedColor;
	public bool selected;

	Color curColor;

	// Use this for initialization
	void Start () {
		curColor = GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () { //Change color if selected
		if (selected)
			GetComponent<Renderer> ().material.color = selectedColor;
		else
			GetComponent<Renderer> ().material.color = curColor;
		
	}
}
