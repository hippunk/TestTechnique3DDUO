using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombLauncher : MonoBehaviour {

	public GameObject bomb;
	public float rateOfFire = 2f;
	public float velocity = 5f;
	public float damage = 10f;
	public float maxRadius = 5f;
	public bool eraseBulletProperties = true;
	public int ammo = 10;
	public GameObject textBombAmmo;

	GameObject curBomb = null;
	float rofTimer;

	// Use this for initialization
	void Start () {
		rofTimer = 0;//rateOfFire;
	}

	// Update is called once per frame
	void Update () {

		rofTimer = (rofTimer<=0)?0:rofTimer-Time.deltaTime; //Timer between attacks

		if (Input.GetMouseButtonDown(0) && curBomb != null) {
			Debug.Log ("Blow");
			curBomb.GetComponent<Bomb> ().Blow ();
			Destroy (curBomb);
			curBomb = null;



		}

		else if (Input.GetMouseButtonDown(0) && rofTimer <= 0 && curBomb == null && ammo > 0) {
			ammo--;
			textBombAmmo.GetComponent<Text> ().text = ammo.ToString();
			Debug.Log ("Fire");
			rofTimer = rateOfFire;
			GameObject proj = Instantiate (bomb,transform.position,transform.rotation);
			if (eraseBulletProperties) {
				proj.GetComponent<ProjMove> ().Velocity = velocity;
				proj.GetComponent<Damage> ().damage = damage;
				proj.GetComponent<Bomb> ().maxRadius = maxRadius;
			}
			curBomb = proj;
		}



	}
}
