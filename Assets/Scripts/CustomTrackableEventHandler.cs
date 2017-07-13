﻿/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;
using RenderHeads.Media.AVProVideo;

namespace Vuforia
{
	/// <summary>
	/// A custom handler that implements the ITrackableEventHandler interface.
	/// </summary>
	public class CustomTrackableEventHandler : MonoBehaviour,
	ITrackableEventHandler
	{

		//public string videoPath;
		#region PRIVATE_MEMBER_VARIABLES

		private TrackableBehaviour mTrackableBehaviour;
		//private bool isForcedTrackingLost = false;
		//private ImageTargetBehaviour ITB;
		//private TouchRotate touchRotate;
		public MediaPlayer mediaPlayer;
		public bool isMenu = false;

		#endregion // PRIVATE_MEMBER_VARIABLES


		public virtual void Start()
		{	
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
//			if (myCanvas) {
//				myCanvas.SetActive (false);
//			}

			//touchRotate = this.GetComponentInChildren<TouchRotate> ();
//			mediaPlayer = this.GetComponentInChildren<MediaPlayer> ();
//			if (mediaPlayer) {
//				mediaPlayer.m_VideoPath = mediaPlayer.m_VideoPath.Replace ("{%persistentPath%}", Application.persistentDataPath);
//				Debug.Log (mediaPlayer.m_VideoPath);
//				mediaPlayer.PostStart ();
//			}
		}



		#region PUBLIC_METHODS

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

		#endregion // PUBLIC_METHODS


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
//			if (touchRotate) {
//				touchRotate.enabled = true;
//			}
			SceneController.currentTrackableObject = this.gameObject;
			Canvas[] canvas = GetComponentsInChildren<Canvas> (true);
			foreach (Canvas ca in canvas) {
				ca.gameObject.SetActive (true);
			}
			//PlayVideo ();
		}

		public void PlayVideo(){
			if(mediaPlayer) {
				//mediaPlayer.OpenVideoFromFile (MediaPlayer.FileLocation.AbsolutePathOrURL, videoPath, true);
				//VCR.instant
				VideoController.instant._videoSeekSlider.gameObject.SetActive(true);
				mediaPlayer.Rewind(false);
				mediaPlayer.Play ();
			}
		}


		virtual protected void OnTrackingLost()
		{
//			if (touchRotate) {
//				touchRotate.enabled = false;
//			}
			SceneController.currentTrackableObject = null;
			Canvas[] canvas = GetComponentsInChildren<Canvas> (true);
			foreach (Canvas ca in canvas) {
				ca.gameObject.SetActive (false);
			}
			StopVideo ();
		}


		public void StopVideo(){
			if (mediaPlayer) {
				VideoController.instant._videoSeekSlider.gameObject.SetActive (false);
				mediaPlayer.Stop ();
			}
		}

//		#endregion // PRIVATE_METHODS
	}
}
