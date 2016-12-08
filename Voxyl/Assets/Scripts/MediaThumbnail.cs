using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class MediaThumbnail : MonoBehaviour {

	public VRInteractiveItem m_InteractiveItem;

	// private string name;
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
		// print("over");
	}

	private void HandleOut() {
		// print("out");
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
		// name = myName;
	}

	public void SetTexture(string myUrl) {
		url = myUrl;	
		
		var tex = Resources.Load(myUrl, typeof(Texture2D)) as Texture2D;

		// should probably chop to size	
		// Texture2D tex = new Texture2D(1,1);
		// tex.LoadImage(bytes);
		
		// int thumbnailWidth = 10;
		// int thumbnailLength = 10;
		// Thumbnail math
		// Unity calls some things length and some things height. Why would it do that?!
		// print(tex.width);
		/*if(tex.height < tex.width) {
			tex.Resize(tex.width * (tex.height / thumbnailLength), tex.height);
			tex.Apply();
		} else {
			// print(((RectTransform)transform).rect.height);	
			//tex.Resize(tex.width, tex.height * (tex.width / thumbnailWidth));
			tex.Resize(1, 1);
			tex.Apply();
		}*/
	
		var renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = tex;
		
		// Image img = GetComponent<Image>();
		// img.canvasRenderer.SetTexture(tex);
	}
}
