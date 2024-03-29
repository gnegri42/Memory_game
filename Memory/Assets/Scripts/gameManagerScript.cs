﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour {

	[HideInInspector]public GameObject 	firstCard = null;
	[HideInInspector]public GameObject 	secondCard = null;
	[HideInInspector]public bool 		canFlip;
	[HideInInspector]public float		timeElapsed;
	[HideInInspector]public int			cardsRemaining;
	public float 						waitingTime = 1f;

	void Start () {
		canFlip = true;
	}
	void Update () {
		// Calculate time of the game
		if (cardsRemaining > 0)
			timeElapsed += Time.deltaTime;
	}

	// Function to get cards in variables in order to compare both of them
	public void AddCard (GameObject card) {
		canFlip = true;
		if (firstCard == null)
			firstCard = card;
		else {
			secondCard = card;
			canFlip = false;

			// If cards are matching, destroy them
			if (CheckCards()) {
				StartCoroutine(DestroyCards());
				cardsRemaining -= 2;
			}
			// Else, turn them back
			else {
				StartCoroutine(FlipBack());
			}
		}
	}

	// Destroy GameObjects of matching cards
	IEnumerator DestroyCards () {
		yield return new WaitForSeconds(waitingTime);
		Destroy(firstCard);
		Destroy(secondCard);
		canFlip = true;
	}

	// Play flip back function of the cards after waiting for a short time
	IEnumerator	FlipBack () {
		yield return new WaitForSeconds(waitingTime);
		firstCard.GetComponent<Animation>().Play("flipCardBack");
		secondCard.GetComponent<Animation>().Play("flipCardBack");
		firstCard.GetComponent<cardScript>().isFlipped = false;
		secondCard.GetComponent<cardScript>().isFlipped = false;
		firstCard = null;
		secondCard = null;
		canFlip = true;
	}

	// Check if cards are the same
	public bool CheckCards () {
		if (firstCard.GetComponent<cardScript>().id == secondCard.GetComponent<cardScript>().id)
			return true;
		return false;
	}
}
