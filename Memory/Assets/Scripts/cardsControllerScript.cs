using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardsControllerScript : MonoBehaviour {
	public List<GameObject>		cardsInGame;
	private int					rows = 3;
	private int					columns = 4;
	public Transform			startPosition;
	private float				xOffset = 4.65f;
	private float				yOffset = 3.1f;
	private gameManagerScript 	gm;
	
	private void Start () {
		gm = FindObjectOfType<gameManagerScript>();
		int maxCards = rows * columns;
		// Create list of cardsNumber depending on the total number of cards we want
		List<int>	cardsNumber = new List<int>();
		for (int i = 0; i < cardsInGame.Count; i++) {
			for (int j = 0; j < 2; j++) {
				cardsNumber.Add(i);				
			}
		}
		gm.cardsRemaining = cardsNumber.Count;
		// Calculate if number of cards will fit on screen
		if (cardsNumber.Count != maxCards)
			Debug.LogError("Cards number is not equal to the number of cards to display");
		// Shuffle the index of spawning cards
		Shuffle(cardsNumber);
		int index = 0;
		// Spawn cards in game
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {
				if (index < maxCards) {
					Instantiate(cardsInGame[cardsNumber[index]],
						new Vector3(startPosition.position.x + xOffset * j, 
							startPosition.position.y - yOffset * i, startPosition.position.z),
						Quaternion.identity);
				}
				index++;
			}
		}
	}

	//Shuffle function to shuffle a list of ints
	private void Shuffle (List<int> cardsNumber) {
		for (int i = 0; i < cardsNumber.Count; i++) {
			int tmp = cardsNumber[i];
			int randomIndex = Random.Range(i, cardsNumber.Count);
			cardsNumber[i] = cardsNumber[randomIndex];
			cardsNumber[randomIndex] = tmp;
		}
	}
}
