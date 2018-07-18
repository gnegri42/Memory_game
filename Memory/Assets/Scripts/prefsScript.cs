using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefsScript : MonoBehaviour {

	//Delete prefs for debug
	public void DeletePrefs() {
		PlayerPrefs.DeleteAll();
	}
}
