using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class AudioThumbnail : MonoBehaviour {
		
	public VRInteractiveItem m_InteractiveItem;
	private string url;
	
	private void OnEnable() {
		m_InteractiveItem.OnClick += HandleClick;
	}

	private void OnDisable() {
		m_InteractiveItem.OnClick -= HandleClick;
	}

	private void HandleClick() {	
		transform.parent.GetComponent<AudioPanel>().CreateAudio(url);
	}

	public void SetUrl(string myUrl) {
		url = myUrl;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
