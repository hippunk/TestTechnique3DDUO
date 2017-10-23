using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTargetMissile : MonoBehaviour {

	public Transform target;
	public float velocity;

	// Update is called once per frame
	void Update () {
		if (target == null)
			Destroy (this.gameObject);
		Vector3 lookPos = target.position - transform.position;

		var rotation = Quaternion.LookRotation(lookPos); //Auto target selected enemy
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime);

		transform.rotation.SetLookRotation (target.transform.position);
		transform.Translate (Vector3.forward*Time.deltaTime*velocity);
		
	}
}
