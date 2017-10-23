using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public GameObject explosion;
	public float maxRadius = 5f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public void Blow(){ //Call blow when click and selected weapon or touch enemy
		GameObject exp = Instantiate (explosion,this.transform.position,Quaternion.identity);
		exp.GetComponent<Explosion> ().maxRadius = maxRadius;
		exp.GetComponent<Damage> ().damage = GetComponent<Damage> ().damage;
	}
}
