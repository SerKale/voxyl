using UnityEngine;
using System.Collections;

public class MediaPanel : MonoBehaviour {

	public Transform media;

	public string url = "TempAssets/chandra.jpg";

	// Use this for initialization
	IEnumerator Start () {
		renderer.material.mainTexture = new Texture2D(4, 4, TextureFormat.DXT1, false);
		while(true) {
			WWW www = new WWW(url);
			yield return www;
			www.LoadImageIntoTexture(renderer.material.mainTexture);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
