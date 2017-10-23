using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DamageShip : MonoBehaviour {

	public float life = 100;
	public GameObject textLife;

	// Use this for initialization
	void Start () {
		textLife.GetComponent<Text> ().text = life.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){ //Life management
		//Destroy(other.gameObject); //will damage the ship if a bullet get to the border
		life -=10;
		textLife.GetComponent<Text> ().text = life.ToString();
		if (life <= 0) {
			SceneManager.LoadScene (2);
		}
			
	}
}
