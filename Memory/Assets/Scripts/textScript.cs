using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textScript : MonoBehaviour {

	public Text					timeText;
	public Text					highScoreText;
	public GameObject			scorePanel;
	private gameManagerScript	gm;

	void Start () {
		gm = FindObjectOfType<gameManagerScript>();
		InitPlayerPrefs();
	}

	// Initialise player prefs
	private void InitPlayerPrefs () {
		if (!PlayerPrefs.HasKey("highScore")) {
			PlayerPrefs.SetFloat("highScore", 0f);
		}
	}
	
	void Update () {
		// If no cards are left, open EndGame menu
		if (gm.cardsRemaining <= 0) {
			// Stop Game Music
			gm.GetComponent<AudioSource>().Stop();

			// Check if actual score is better than HighScore
			if (PlayerPrefs.GetFloat("highScore") == 0 ||
					PlayerPrefs.GetFloat("highScore") > gm.timeElapsed) {
				PlayerPrefs.SetFloat("highScore", gm.timeElapsed);
			}
			StartCoroutine(EndGame());
		}
	}

	// Display EndGame
	IEnumerator EndGame () {
		yield return new WaitForSeconds(1.0f);
		scorePanel.SetActive(true);
		timeText.text = "Your score : " + gm.timeElapsed.ToString("F2") + " secondes";
		highScoreText.text = "High Score : " +  PlayerPrefs.GetFloat("highScore").ToString("F2");
	}
}
