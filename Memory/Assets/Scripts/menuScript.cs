using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {
	
	//Play sound and go to Game
	public void PlayGame () {
		StartCoroutine(NewGame());
	}

	IEnumerator NewGame () {
		GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(.4f);
		SceneManager.LoadScene("Game");
	}

	public void BackToMenu () {
		SceneManager.LoadScene("MainMenu");
	}
}
