using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using System.Collections.Generic;

public class AudioPanel : MonoBehaviour {

	public Transform audioThumbnailTemplate;
	public Transform m_AudioSpawner;
	
	public VRInput m_VrInput;

	private int index = 0;

	private string[,] files = new string[,] {
			{"Careless Whisper - George Michael", "carelesswhisper"},
			{"Closer - The Chainsmokers ft. Halsey", "closer"},
			{"Careless Whisper - George Michael", "carelesswhisper"},
			{"Closer - The Chainsmokers ft. Halsey", "closer"},
			{"Careless Whisper - George Michael", "carelesswhisper"},
			{"Closer - The Chainsmokers ft. Halsey", "closer"}
		};

	private const int CLIPS_PER_PAGE = 9;
	private int maxIndex;
	
	private void OnEnable() {
		m_VrInput.OnSwipe += HandleSwipe;
	}

	private void OnDisable() {
		m_VrInput.OnSwipe -= HandleSwipe;
	}
	
	// Use this for initialization
	void Start () {
		maxIndex = files.GetLength(0) / CLIPS_PER_PAGE;
		RenderThumbnailsForIndex(index);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateAudio(string url) {
		// consider doing this with first class functions
		// This function, I think, is what would get passed in
		m_AudioSpawner.GetComponent<AudioSpawner>().CreateAudio(url);

		// eventually move this out?
		gameObject.SetActive(false);
	}

	private void HandleSwipe(VRInput.SwipeDirection dir) {
		if(gameObject.activeSelf) {
			switch(dir) {
				case VRInput.SwipeDirection.UP:	
					if(index > 0) { RenderThumbnailsForIndex(--index); }
					break;
				
				case VRInput.SwipeDirection.DOWN:	
					if(index < maxIndex) { RenderThumbnailsForIndex(++index); }
					break;
			}
		}
	}

	private void RenderThumbnailsForIndex(int index) {		
		int numfiles = files.GetLength(0);
		
		// clear images
		var children = new List<GameObject>();
		foreach (Transform child in transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

		// render images
		int start = index * CLIPS_PER_PAGE;
		int num = start + CLIPS_PER_PAGE > numfiles ? numfiles - start : CLIPS_PER_PAGE;
		for(int i = 0; i < num; i++) {
			Transform obj = (Transform) Instantiate(audioThumbnailTemplate);
			Vector3 originalScale = obj.transform.localScale;	
			obj.transform.parent = transform;
			obj.transform.localPosition = new Vector3(-3f + 3f * (i/3), .2f, -3.5f + 3f * (i%3));
			obj.transform.rotation = new Quaternion(0,0,0,0);
			obj.transform.Rotate(0, -90, 0);
			obj.transform.localScale = originalScale;
			var text = obj.GetChild(0).GetComponent<TextWrap>();
			text.Initialize();
			text.SizeToFit(files[start + i, 0]);
			obj.GetComponent<AudioThumbnail>().SetUrl(files[start + i, 1]);
		}
	}
}
