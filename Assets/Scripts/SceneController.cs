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
	public static SceneController instant;

	void Awake(){
		instant = this;
	}

	// Use this for initialization
	void Update(){
		text.gameObject.SetActive (!slider.activeSelf);
//		if (slider.activeSelf) {
//			topText.text = text.text;
//			backButton.SetActive (true);
//		} else {
//			topText.text = "";
//			backButton.SetActive (false);
//		}
	}

	//showing 3d object
	public void ShowBackButtonOnly(){
		text.gameObject.SetActive (true);
		topText.text = "";
		backButton.SetActive (true);
	}

	//showing video
	public void ShowTop(){
		text.gameObject.SetActive (false);
		topText.text = text.text;
		backButton.SetActive (true);
	}

	public void HideAll(){
		topText.text = "";
		if(backButton!=null)backButton.SetActive (false);
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
