using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour {

	public List<MonoBehaviour> weapons = new List<MonoBehaviour>();
	public int curWeapon;
	public Color selectedColor;
	public GameObject panelGun;
	public GameObject panelMissiles;
	public GameObject panelBombs;

	Color def;

	// Use this for initialization
	void Start () {
		curWeapon = 0;

		foreach (MonoBehaviour weapon in weapons) {
			weapon.enabled = false;
		}
		weapons [curWeapon].enabled = true;		
		def = panelGun.GetComponent<Image> ().color;
		panelGun.GetComponent<Image> ().color = selectedColor;
	}
	
	// Update is called once per frame
	void Update () {
		//Input.mouseScrollDelta
		float axis = 0;
		if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
		{
			weapons [curWeapon].enabled = false;
			curWeapon = (3+(curWeapon-1))%weapons.Count; //FixValue
			weapons [curWeapon].enabled = true;
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
		{
			weapons [curWeapon].enabled = false;
			curWeapon = (3+(curWeapon+1))%weapons.Count;
			weapons [curWeapon].enabled = true;
		}


		if (curWeapon == 0) {//Dirty lack of time feedback for selected weapon
			panelGun.GetComponent<Image> ().color = selectedColor;
			panelMissiles.GetComponent<Image> ().color = def;
			panelBombs.GetComponent<Image> ().color = def;
		}

		if (curWeapon == 1) {
			panelGun.GetComponent<Image> ().color = def;
			panelMissiles.GetComponent<Image> ().color = selectedColor;
			panelBombs.GetComponent<Image> ().color = def;
		}


		if (curWeapon == 2) {
			panelGun.GetComponent<Image> ().color = def;
			panelMissiles.GetComponent<Image> ().color = def;
			panelBombs.GetComponent<Image> ().color = selectedColor;
		}

	}
}
