/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;
using RenderHeads.Media.AVProVideo;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Vuforia
{
	/// <summary>
	/// A custom handler that implements the ITrackableEventHandler interface.
	/// </summary>
	public class TrackableMenuEventHandler : MonoBehaviour,
	ITrackableEventHandler
	{

		public PopMenuItem[] menuItems;
		//public List<Vector3> origScales ; 
		//public float moveX = 0.3f;
		//public float moveY = 0.07f;
		//public float moveZ = 0.13f;
		//public float startTween = 1f;
		//public GameObject playerPlane;
		//public startTweens[];
		private TrackableBehaviour mTrackableBehaviour;
		public Material playerMateral;


		public virtual void Start()
		{	
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
			for (int i = 0; i < menuItems.Length; i++) {
				menuItems [i].index = i;
			}
		}

		/// <summary>
		/// Implementation of the ITrackableEventHandler function called when the
		/// tracking state changes.
		/// </summary>
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound();
			}
			else
			{
				OnTrackingLost();
			}
		}

		//		public void OnForcedLostTracking(){
		//
		//			isForcedTrackingLost = true;
		//			OnTrackingLost ();
		//
		//		}


		//		#endregion // PUBLIC_METHODS



		//		#region PRIVATE_METHODS


		virtual protected void OnTrackingFound()
		{
			StartCoroutine (PopAllItems());
			//playerPlane.SetActive (false);
			//PopAllItems();
		}

		IEnumerator PopAllItems(){
			for (int i = 0; i < menuItems.Length; i++) {
				menuItems [i].gameObject.SetActive (false);
			}
			List<int> idxes = Utils.RandomIntArray (4);
			Debug.Log (idxes);
			for (int j = 0; j < menuItems.Length; j++) {
				int i = idxes [j];
				menuItems [i].Zoom ();
				yield return new WaitForSeconds (0.3f);
			}
		}

//		void ItemStart(PopMenuItem item)
//		{
//			Debug.Log ("ItemStart " + item.name);
//			item.gameObject.SetActive (true);
//		}


		void ItemIdle(PopMenuItem item)
		{
			for (int i = 0; i < menuItems.Length; i++) {
				menuItems [i].Idle ();
			}
		}


		virtual protected void OnTrackingLost()
		{
			//playerPlane.SetActive (false);
			for (int i = 0; i < menuItems.Length; i++) {
				menuItems [i].Reset ();
			}

		}


		public void HideAllItems(int exception = -1){
			for (int i = 0; i < menuItems.Length; i++) {
				menuItems [i].gameObject.SetActive (exception == i);
				menuItems [i].StopIdle ();
				menuItems [i].transform.DOKill ();
			}
		}
		//		#endregion // PRIVATE_METHODS
	}
}
