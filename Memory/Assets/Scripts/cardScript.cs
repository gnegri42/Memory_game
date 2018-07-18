using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardScript : MonoBehaviour {
	[HideInInspector]public bool		isFlipped = false;
	private Animation		objAnim;
	private SpriteRenderer 	sr;
	private AudioSource		audioSrc;
	public int				id;
	public Sprite			frontCard;
	public Sprite			backCard;
	private gameManagerScript gm;

	void Start () {
		objAnim = gameObject.GetComponent<Animation>();
		sr = gameObject.GetComponent<SpriteRenderer>();
		gm = FindObjectOfType<gameManagerScript>();
		audioSrc = gameObject.GetComponent<AudioSource>();
	}
	
	void Update () {
		// Display the front of the card if clicked
		if (gameObject.transform.rotation.y <= -0.5) {
			sr.sprite = frontCard;
		}
		else // Else display the back
			sr.sprite = backCard;
	}

	void OnMouseOver()
    {
		//Change color if mouse is over the card
		if (isFlipped == false && gm.canFlip == true) {
			sr.color = new Color(0.366f, 0.6267f, 0.7547f, 1f);
		}
		// Can click if the card is not already flipped and if both cards are back to clickable state
		if (Input.GetMouseButtonDown(0) && isFlipped == false && gm.canFlip == true) {
			// Play flip card sound
			audioSrc.Play();
			// Rotate card on click
			objAnim.Play("flipCardClick");
			isFlipped = true;
			// Add card to the Game Manager
			gm.AddCard(gameObject);
    	}
	}

	// Go back to normal color when mouse is out of the object
	void OnMouseExit() {
		sr.color = Color.white;	
	}
}
