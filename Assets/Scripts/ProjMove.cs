using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjMove : MonoBehaviour {


	public float timeToLive = 10f;

	float velocity = 2f; //Here velocity depends on weapons
	float ttlTimer = 0f;

	public float Velocity {

		set {
			velocity = value;
		}
	}


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		ttlTimer += Time.deltaTime;

		transform.Translate (Vector3.forward*Time.deltaTime*velocity);

		if (ttlTimer >= timeToLive) {
			if (this.gameObject.GetComponent<Bomb> ()) {
				this.gameObject.GetComponent<Bomb> ().Blow();
			}
			Destroy (this.gameObject);
		}
	}
}
