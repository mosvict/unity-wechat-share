using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class NativeShare_Example : MonoBehaviour
{


	//SetProject Write Access to External (SDCard)

	public Texture2D m_texture;
	public Slider m_slider;


	EventSystem eventSystem;

	void Start(){
		

		eventSystem =  EventSystem.current;

		m_slider.maxValue = 100;
	
	
	}

	void OnEnable(){
		NativeShare.OnDownloading += OnDownLoading;
		NativeShare.OnDownloadCompleted +=OnDownLoadCompleted;
		NativeShare.OnShareCompleted +=	OnShareCompleted;
	}


	void OnDisable(){
		NativeShare.OnDownloading -= OnDownLoading;
		NativeShare.OnDownloadCompleted -=OnDownLoadCompleted;
		NativeShare.OnShareCompleted -=	OnShareCompleted;

	}


	void OnDownLoading(float progress){
		
		eventSystem.enabled = false;

		if(progress > 0)
		m_slider.transform.parent.gameObject.SetActive (true);

		m_slider.value = progress;
	}
	void OnDownLoadCompleted(){

		eventSystem.enabled = true;
		m_slider.transform.parent.gameObject.SetActive (false);
		m_slider.value = 0;
	}


	void OnShareCompleted(NativeShare.SharingResult result){

		Debug.Log ("OnShareCompleted Callback: "+ result);


	}


	public void SendText(){
		NativeShare.ShareText ("https://www.google.com");

	}
	public void ShareTexture(){
		
		NativeShare.ShareTexture(m_texture);



	}

	public void SocialShareFacebook(){


		List<string> files = new List<string> ();
		files.Add (Path.Combine (Application.streamingAssetsPath, "logo.png"));
		files.Add ("http://d2ujflorbtfzji.cloudfront.net/key-image/bf8bdf81-e668-4786-ae63-245e6828e7c3.jpg");

		NativeShare.ShareFiles(files.ToArray(),ShareApp.Facebook);



	}


	public void DownloadAndShareTwitter(){

		NativeShare.ShareFile("http://d2ujflorbtfzji.cloudfront.net/key-image/bf8bdf81-e668-4786-ae63-245e6828e7c3.jpg",ShareApp.Twitter);
	}

	public void SendEmail(){

		List<string> files = new List<string> ();
		files.Add (Path.Combine (Application.streamingAssetsPath, "logo.png"));
		files.Add (Path.Combine (Application.streamingAssetsPath, "panda.mov"));


		List<string> emails = new List<string> ();
		emails.Add("cinowacs@gmail.com");
		emails.Add("euw.icon@gmail.com");



		NativeShare.SendEmail (files.ToArray(), "Subject", "Hello", emails.ToArray());


	}



	public void ShareInstagram(){

		NativeShare.ShareFile (Path.Combine (Application.streamingAssetsPath, "cat_party.gif"),ShareApp.Facebook);
	}










}


