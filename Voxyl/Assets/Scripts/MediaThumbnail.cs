using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class MediaThumbnail : MonoBehaviour {

	public VRInteractiveItem m_InteractiveItem;

	private string name;
	private string url;

	private void OnEnable() {
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_InteractiveItem.OnClick += HandleClick;
	}

	private void OnDisable() {
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		m_InteractiveItem.OnClick -= HandleClick;
	}

	private void HandleOver() {
		print("over");
		// print(base);
		// var parent = pr
	}

	private void HandleOut() {
		print("out");
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

	public void Initialize(string myName) {
		name = myName;
		// parent = parent;
	}

	public void SetTexture(string myUrl) {
		url = myUrl;	
		
		var bytes = System.IO.File.ReadAllBytes(myUrl);

		// should probably chop to size	
		Texture2D tex = new Texture2D(1,1);
		tex.LoadImage(bytes);	
		
		var renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = tex;
		// renderer.material.color -= new Color(1,0,0,.5f);
		
		// Get current image
		// print("Hey there!");
		// print(this.overrideSprite);
		// Image img = GetComponent<Image>();
		// img.canvasRenderer.SetTexture(tex);
	}
}
