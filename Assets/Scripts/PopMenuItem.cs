using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Vuforia;

public class PopMenuItem : MonoBehaviour {

	private float origY;
	private Vector3 origPosition;
	private Vector3 origScale;
	private bool isIdle;
	public float floatSpeed = 1;
	public float floatAmplitude = 0.1f;
	private float tick;
	public int index;
	public TrackableMenuEventHandler trackableMenu;
	public CustomTrackableEventHandler trackableHandler;
	private MeshRenderer meshRenderer;
	private Material material;

	public void Start(){
		origY = this.transform.localPosition.y;
		origPosition = this.transform.localPosition;
		origScale = this.transform.localScale;
		meshRenderer = GetComponent<MeshRenderer> ();
		material = meshRenderer.material;
		//transform = GetComponent<Transform> ();
	}

	public void Reset(){
		isIdle = false;
		gameObject.SetActive (true);
		transform.localPosition = origPosition;
		transform.localScale = origScale;
		meshRenderer.material = material;
	}


	public void Idle(){
		isIdle = true;
		tick = 0;
	}

	public void StopIdle(){
		isIdle = false;
		//this.transform.localPosition = this.transform.localPosition.SetY (origY);
	}

	public void Zoom(){

		transform.localScale = new Vector3(origScale.x * 0.3f, origScale.y * 0.3f,origScale.z * 0.3f);
		transform.localPosition = Vector3.zero;
		gameObject.SetActive (true);
		//menuItems [0].transform.DOMove (new Vector3(0,0,0),3);
		transform.DOScale (origScale,	0.5f);
		Vector3 moveTo = Vector3.zero;
//		if (i == 0) {
//			moveTo = new Vector3(-moveX,moveY,moveZ);
//		}else if (i == 1) {
//			moveTo = new Vector3(moveX,moveY,moveZ);
//		}else if (i == 2) {
//			moveTo = new Vector3(-moveX,moveY,-moveZ);
//		}else if (i == 3) {
//			moveTo = new Vector3(moveX,moveY,-moveZ);
//		}
		//menuItems [i].transform.DOMove (moveTo,startTween).SetEase(Ease.OutCubic).SetDelay(UnityEngine.Random.Range (0f, 0.5f)).OnComplete(menuItems [i].Idle);
		transform.DOMove (origPosition,0.5f).SetEase(Ease.OutCubic).OnComplete(Idle);

	}


	void Update(){
		if (isIdle) {
			tick += Time.deltaTime * floatSpeed;
			this.transform.localPosition = this.transform.localPosition.SetY (origY + Mathf.Sin(tick)* floatAmplitude);
		}
//		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
//			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
//			RaycastHit hit;
//			if (Physics.Raycast(ray, out hit, 100)){
//			// the object identified by hit.transform was clicked
//			// do whatever you want
//				Debug.Log(index.ToString() + " is HIT!!!");
//				hit.
//			}
//		}
	}

	void OnMouseDown(){

		Debug.Log(index.ToString() + " is HIT!!!");
		StopIdle ();
		transform.DOMove (new Vector3(0,origPosition.y*2, 0),0.3f).SetEase(Ease.OutQuad);
		transform.DOScale (origScale * 2,0.3f).SetEase(Ease.OutQuad).OnComplete(PlayVideo);
	}

	void PlayVideo(){
		trackableMenu.HideAllItems (index);
		trackableHandler.PlayVideo ();
		meshRenderer.material = trackableMenu.playerMateral;
		//trackableMenu.playerPlane.SetActive (true);
	}
}
