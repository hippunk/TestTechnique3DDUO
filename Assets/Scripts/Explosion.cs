using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public float maxRadius = 5f;
	Vector3 maxExplo;// = new Vector3 (maxRadius, maxRadius, maxRadius);

	// Use this for initialization
	void Start () {
		maxExplo = new Vector3 (maxRadius, maxRadius, maxRadius);
	}

	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.Lerp(transform.localScale,maxExplo, Time.deltaTime);
		if (transform.localScale.x > maxExplo.x*0.9f) {
			Destroy (this.gameObject);
		}

	}
}
