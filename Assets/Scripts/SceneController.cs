using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class SceneController : MonoBehaviour {

	public GameObject slider;
	public Text text;
	public Text topText;
	public GameObject backButton;
	public static GameObject currentTrackableObject;

	// Use this for initialization
	void Update(){
		text.gameObject.SetActive (!slider.activeSelf);
		if (slider.activeSelf) {
			topText.text = text.text;
			backButton.SetActive (true);
		} else {
			topText.text = "";
			backButton.SetActive (false);
		}
	}

	public void OnBackClick(){
		if (currentTrackableObject != null) {
			TrackableMenuEventHandler ev = currentTrackableObject.gameObject.GetComponent<TrackableMenuEventHandler> ();
			if (ev!=null) {
				ev.ShowMenu ();
			}
		}
	}
}
