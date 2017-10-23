using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour {

	public GameObject bullet;
	public float rateOfFire = 2f;
	public float velocity = 5f;
	public float damage = 10f;
	public bool eraseBulletProperties = true;
	public int ammo = 1000;
	public GameObject textAmmoTurret;

	float rofTimer;

	// Use this for initialization
	void Start () {
		rofTimer = 0;//rateOfFire;
	}
	
	// Update is called once per frame
	void Update () {

		rofTimer = (rofTimer<=0)?0:rofTimer-Time.deltaTime; //Timer between attacks


		if (Input.GetMouseButton(0) && rofTimer <= 0 && ammo > 0) {
			ammo--;
			textAmmoTurret.GetComponent<Text> ().text = ammo.ToString();
			Debug.Log ("Fire");
			rofTimer = rateOfFire;
			GameObject proj = Instantiate (bullet,transform.position,transform.rotation);
			if (eraseBulletProperties) {
				proj.GetComponent<ProjMove> ().Velocity = velocity; //properties transfert between objects for easy settings management
				proj.GetComponent<Damage> ().damage = damage;
			}
		
		}
		
	}
}
