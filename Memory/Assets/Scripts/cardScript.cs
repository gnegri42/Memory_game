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

	// Use this for initialization
	void Start () {
		objAnim = gameObject.GetComponent<Animation>();
		sr = gameObject.GetComponent<SpriteRenderer>();
		gm = FindObjectOfType<gameManagerScript>();
		audioSrc = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// Display the front of the card if clicked
		////////////////// TO DO Change to add a coroutine to optimize and not check at every update
		if (gameObject.transform.rotation.y <= -0.5) {
			sr.sprite = frontCard;
		}
		else
			sr.sprite = backCard;			
	}

	void OnMouseOver()
    {
		// Debug.Log("gm.canFlip : " + gm.canFlip);
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
}
