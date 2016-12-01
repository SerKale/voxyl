using UnityEngine;
using System.Collections;

public class MediaPanel : MonoBehaviour {

	public Transform mediaThumbnailTemplate;
	public Transform m_ImageSpawner;

	// Use this for initialization
	void Start () {
		
		/*string url = "Assets/Temp Assets/chandra.jpg";
		var bytes = System.IO.File.ReadAllBytes(url);

		Texture2D tex = new Texture2D(1,1);
		tex.LoadImage(bytes);	
		var renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = tex;
		renderer.material.color -= new Color(1,0,0,.5f);*/

		// load media snapshots
		// var obj = Instantiate(mediaThumbnailTemplate, new Vector3(0,0,0), Quaternion.identity) as Media;
		// print(GetComponent<RectTransform>());
		// print(obj);	
		// obj.transform.parent = transform;
		
		/*var obj = createThumbnail();
	
		var url = "Assets/Temp Assets/chandra.jpg";
		var bytes = System.IO.File.ReadAllBytes(url);
		Texture2D tex = new Texture2D(1,1);
		tex.LoadImage(bytes);
		Image img = obj.GetComponent<Image>();
		img.canvasRenderer.SetTexture(tex);*/

		//Transform obj = (Transform) Instantiate(mediaThumbnailTemplate, new Vector3(0,0,0), Quaternion.identity);

		string[,] files = new string[,] {
			{"White", "whitemana.png"},
			{"Blue", "bluemana.png"},
			{"Black", "blackmana.png"},
			{"Red", "redmana.png"},
			{"Green", "greenmana.png"}
		};
		
		for(int i = 0; i < files.GetLength(0); i++) {
			Transform obj = (Transform) Instantiate(mediaThumbnailTemplate);
			Vector3 originalScale = obj.transform.localScale;	
			obj.transform.parent = transform;
			obj.transform.localPosition = new Vector3(-3f + 3f * (i/3), .2f, -3.5f + 3f * (i%3));
			obj.transform.rotation = new Quaternion(0,0,0,0);
			obj.transform.Rotate(0, 90, 0);
			obj.transform.localScale = originalScale;
			obj.GetComponent<MediaThumbnail>().SetTexture("Assets/Temp Assets/" + files[i, 1]);
			obj.GetComponent<MediaThumbnail>().Initialize(files[i, 0]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*Transform createThumbnail() {
		var obj = Instantiate(mediaThumbnailTemplate);
		obj.transform.SetParent(GetComponent<RectTransform>(), false);
		print(obj.GetComponent<CanvasRenderer>());
		obj.transform.position = new Vector3(0,0,0);
		obj.transform.rotation = new Quaternion(45, 45, 45, 45);
		return obj;
	}*/

	public void CreateImage(string tag) {
		// consider doing this with first class functions
		print(tag);
		m_ImageSpawner.GetComponent<AddPhotoButton>().CreateImage(tag);
	}
}
