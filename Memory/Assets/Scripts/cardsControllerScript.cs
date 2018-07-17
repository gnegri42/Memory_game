using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardsControllerScript : MonoBehaviour {
	public List<GameObject>		cardsInGame;
	public List<int>			cardsNumber;
	private int					rows = 3;
	private int					columns = 4;
	public Transform			startPosition;
	private float				xOffset = 4.65f;
	private float				yOffset = 3.1f;
	
	private void Start () {
		int maxCards = rows * columns;

		if (cardsNumber.Count != maxCards)
			Debug.LogError("Cards number is not equal to the number of cards to display");
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

	private void Shuffle (List<int> cardsNumber) {
		for (int i = 0; i < cardsNumber.Count; i++) {
			int tmp = cardsNumber[i];
			int randomIndex = Random.Range(i, cardsNumber.Count);
			cardsNumber[i] = cardsNumber[randomIndex];
			cardsNumber[randomIndex] = tmp;
		}
	}
}
