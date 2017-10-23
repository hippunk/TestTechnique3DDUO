using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Life : MonoBehaviour {

	public float life = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (life <= 0) {
			ScoreHandler scoreHandler = FindObjectOfType<ScoreHandler> ();
			scoreHandler.addScore (1);
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){ //Life management
		if (other.gameObject.GetComponent<Damage> ()) {
			life -= other.gameObject.GetComponent<Damage> ().damage;

		}

		if (other.gameObject.GetComponent<Bomb> ()) {
			other.gameObject.GetComponent<Bomb> ().Blow();
		}
		if (!other.gameObject.GetComponent<Explosion> () && !other.gameObject.GetComponent<DamageShip> ()) { //Dirty way to fix some collision detection issues
			Destroy (other.gameObject);
		}
	}
}
