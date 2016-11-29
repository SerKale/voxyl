using UnityEngine;
using System.Collections;

public class MediaPanel : MonoBehaviour {

	public Transform mediaTemplate;

	public string url = "TempAssets/chandra.jpg";

	// Use this for initialization
	void Start () {
		/* renderer.material.mainTexture = new Texture2D(4, 4, TextureFormat.DXT1, false);
		while(true) {
			WWW www = new WWW(url);
			yield return www;
			// www.LoadImageIntoTexture(renderer.material.mainTexture);
			renderer.material.mainTexture = www.texture;
		}*/
		
		/* string url = "Assets/Temp Assets/chandra.jpg";
		print(System.IO.File.Exists(url));
		var bytes = System.IO.File.ReadAllBytes(url);

		Texture2D tex = new Texture2D(1,1);
		tex.LoadImage(bytes);
		GetComponent<Renderer>().material.mainTexture = tex;*/

		// load media snapshots
		var obj = Instantiate(mediaTemplate, new Vector3(-3,-3,-3), Quaternion.identity);
		// obj.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
