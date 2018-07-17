using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardScript : MonoBehaviour {
	[HideInInspector]public bool		isFlipped = false;
	private Animation		objAnim;
	private SpriteRenderer 	sr;
	public int				id;
	public Sprite			frontCard;
	public Sprite			backCard;
	private gameManagerScript gm;

	// Use this for initialization
	void Start () {
		objAnim = gameObject.GetComponent<Animation>();
		sr = gameObject.GetComponent<SpriteRenderer>();
		gm = FindObjectOfType<gameManagerScript>();
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
		if (Input.GetMouseButtonDown(0) && isFlipped == false) {
			// Rotate card on click
			objAnim.Play("flipCardClick");
			isFlipped = true;
			// Add card to the Game Manager
			gm.AddCard(gameObject);
    	}
	}
}
