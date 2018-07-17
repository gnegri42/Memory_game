﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour {

	[HideInInspector]public GameObject 	firstCard = null;
	[HideInInspector]public GameObject 	secondCard = null;
	[HideInInspector]public int			cardsRemaining;
	[HideInInspector]public bool 		canFlip;

	// Function to get cards in variables in order to compare both of them
	public void AddCard (GameObject card) {
		if (firstCard == null)
			firstCard = card;
		else {
			secondCard = card;
			canFlip = false;

			// If cards are matching, destroy them
			if (CheckCards()) {
				DestroyCards();
				cardsRemaining -= 2;
				if (cardsRemaining <= 0) {
					//////////////////////////TO DO Load endgame screen
				}
			}
			// Else, turn them back
			else {
				FlipBack();
			}
		}
	}

	// Destroy gameobjects of matching cards
	public void DestroyCards () {
		Destroy(firstCard);
		Destroy(secondCard);
	}

	// Play flip back function of the cards
	public void	FlipBack () {
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