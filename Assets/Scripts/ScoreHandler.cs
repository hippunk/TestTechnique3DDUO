using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreHandler : MonoBehaviour {

	public int score = 0;
	public int remainingTime = 3000;
	public GameObject scoreText;
	public GameObject time;

	void Update(){
		remainingTime--;
		time.GetComponent<Text> ().text = remainingTime.ToString ();

		if (remainingTime <= 0) {
			SceneManager.LoadScene (3);
		}
	}

	public void addScore(int pts){
		score += pts;
		scoreText.GetComponent<Text> ().text = score.ToString ();
	}
}
