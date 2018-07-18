using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textScript : MonoBehaviour {

	public Text					timeText;
	public GameObject			scorePanel;
	public AudioSource			victorySound;
	private gameManagerScript	gm;

	void Start () {
		gm = FindObjectOfType<gameManagerScript>();
	}
	
	void Update () {
		// If no cards are left, open EndGame menu
		if (gm.cardsRemaining <= 0) {
			gm.GetComponent<AudioSource>().Stop();
			StartCoroutine(EndGame());
		}
	}

	IEnumerator EndGame () {
		yield return new WaitForSeconds(1.0f);
		scorePanel.SetActive(true);
		victorySound.Play();
		timeText.text = "Votre score : " + gm.timeElapsed.ToString("F2") + " secondes";
	}
}
