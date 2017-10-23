using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileLauncher : MonoBehaviour {

	public GameObject missile;
	public float rateOfFire = 2f;
	public float velocity = 5f;
	public int maxTarget = 2;
	public float damage = 10f;
	public bool eraseBulletProperties = true;
	public int ammo = 50;
	public GameObject textMissleAmmo;

	bool selecting = false;
	bool launch = false;
	List<GameObject> targets = new List<GameObject> ();

	public float rofTimer;

	// Use this for initialization
	void Start () {
		rofTimer = 0;//rateOfFire;
	}

	void FixedUpdate(){


		//Target locking management using raycast and target painting for user feedbask
		if (selecting && targets.Count < maxTarget) {//Selection behavior
			Debug.Log (targets.Count );
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit,Mathf.Infinity)) {
				if (hit.collider.gameObject.GetComponent<Selected> () && hit.collider.gameObject.GetComponent<Selected> ().selected == false) {
					targets.Add (hit.collider.gameObject);
					hit.collider.gameObject.GetComponent<Selected> ().selected = true;
					launch = true;
				}
			}
				
			//var objectTouching = hit.collider.name;
			//print(objectTouching);
			//currentObjectOver = hit.collider.gameObject;
		}
	}

	// Update is called once per frame
	void Update () {
		rofTimer = (rofTimer<=0)?0:rofTimer-Time.deltaTime; //Timer between attacks


		if (Input.GetMouseButtonDown(0) && rofTimer <= 0 && ammo > 0) {
			Debug.Log ("Select");
			selecting = true;



		}

		if (Input.GetMouseButtonUp(0) && rofTimer <= 0) {
			Debug.Log ("Launch");
			rofTimer = rateOfFire;
			selecting = false;
			ammo-=targets.Count;
			textMissleAmmo.GetComponent<Text> ().text = ammo.ToString();
				foreach (GameObject go in targets) {
					Selected sel = go.GetComponent<Selected> ();
					sel.selected = false;
					GameObject proj = Instantiate (missile, transform.position, transform.rotation); //There is ways to generalize projectiles, but not enouth time
					if (eraseBulletProperties) {
						proj.GetComponent<AutoTargetMissile> ().velocity = velocity; //properties transfert between objects for easy settings management
						proj.GetComponent<AutoTargetMissile> ().target = go.transform;
						proj.GetComponent<Damage> ().damage = damage;
					}
				}
				targets.Clear ();

			//Instantiate missles per selected

			//GameObject proj = Instantiate (missile,transform.position,transform.rotation);
			//proj.GetComponent<BulletScript> ().Velocity = velocity;

		}

	}
}
