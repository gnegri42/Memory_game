using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textScript : MonoBehaviour {

	public Text					timeText;
	public GameObject			scorePanel;
	private gameManagerScript	gm;

	// Use this for initialization
	void Start () {
		gm = FindObjectOfType<gameManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gm.cardsRemaining <= 0) {
			scorePanel.SetActive(true);
			timeText.text = "Votre score : " + gm.timeElapsed + " secondes";
		}
	}
}
