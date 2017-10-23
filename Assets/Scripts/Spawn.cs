using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject enemy;
	public float rateOfFire = 2f;
	public float velocity = 5f;
	float rofTimer;
	public List<GameObject> spawns = new List<GameObject>();

	// Use this for initialization
	void Start () {
		rofTimer = 0;//rateOfFire;
	}
	
	// Update is called once per frame
	void Update () {
		rofTimer = (rofTimer<=0)?0:rofTimer-Time.deltaTime; //Timer between attacks

		if (rofTimer <= 0) {
			Debug.Log ("Pop");
			rofTimer = rateOfFire;
			foreach (GameObject go in spawns) { //Should be better to have different enemies and spawn randomly
				GameObject en = Instantiate (enemy, go.transform.position, enemy.transform.rotation);
				en.GetComponent<EnemyMovement> ().velocity = velocity;
			
			}
		}
	}
}
