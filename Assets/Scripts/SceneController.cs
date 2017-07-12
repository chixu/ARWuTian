using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

	public GameObject slider;
	public GameObject text;

	// Use this for initialization
	void Update(){
		text.SetActive (!slider.activeSelf);
	}
}
