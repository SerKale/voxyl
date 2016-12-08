using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class MediaThumbnail : MonoBehaviour {

	public VRInteractiveItem m_InteractiveItem;
	
	private string url;

	private void OnEnable() {
		m_InteractiveItem.OnClick += HandleClick;
	}

	private void OnDisable() {
		m_InteractiveItem.OnClick -= HandleClick;
	}	

	private void HandleClick() {	
		transform.parent.GetComponent<MediaPanel>().CreateImage(url);
	}

	// Use this for initialization
	void Start () {	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}	

	public void SetTexture(string myUrl) {
		url = myUrl;	
		
		var tex = Resources.Load(myUrl, typeof(Texture2D)) as Texture2D;
		var renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = tex;

		// TODO: Write thumbnail cropping code
	}
}
