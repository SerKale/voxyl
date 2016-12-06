using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using System.Collections.Generic;

public class MediaPanel : MonoBehaviour {

	public Transform mediaThumbnailTemplate;
	public Transform m_ImageSpawner;
	
	public VRInput m_VrInput;

	private int index = 0;

	private string[,] files = new string[,] {
			{"White", "whitemana"},
			{"Blue", "bluemana"},
			{"Black", "blackmana"},
			{"Red", "redmana"},
			{"Green", "greenmana"},
			{"White", "whitemana"},
			{"Blue", "bluemana"},
			{"Black", "blackmana"},
			{"Red", "redmana"},
			{"Green", "greenmana"},
			{"White", "whitemana"},
			{"Blue", "bluemana"},
			{"Black", "blackmana"},
			{"Red", "redmana"},
			{"Green", "greenmana"},
			{"Chandra", "chandra"}
		};

	private const int IMAGES_PER_PAGE = 9;
	private int maxIndex;
	
	private void OnEnable() {
		m_VrInput.OnSwipe += HandleSwipe;
	}

	private void OnDisable() {
		m_VrInput.OnSwipe -= HandleSwipe;
	}
	
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

		
		
		/*int numfiles = files.GetLength(0);
		for(int i = index * 9; i < (numfiles > 9 ? 9 : numfiles); i++) {
			Transform obj = (Transform) Instantiate(mediaThumbnailTemplate);
			Vector3 originalScale = obj.transform.localScale;	
			obj.transform.parent = transform;
			obj.transform.localPosition = new Vector3(-3f + 3f * (i/3), .2f, -3.5f + 3f * (i%3));
			obj.transform.rotation = new Quaternion(0,0,0,0);
			obj.transform.Rotate(0, 90, 0);
			obj.transform.localScale = originalScale;
			obj.GetComponent<MediaThumbnail>().SetTexture("Assets/Images/" + files[i, 1]);
			obj.GetComponent<MediaThumbnail>().Initialize(files[i, 0]);
		}*/

		maxIndex = files.GetLength(0) / IMAGES_PER_PAGE;

		RenderImagesForIndex(index);

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

	public void CreateImage(string url) {
		// consider doing this with first class functions
		// This function, I think, is what would get passed in
		// print(tag);
		m_ImageSpawner.GetComponent<AddPhotoButton>().CreateImage(url);

		// eventually move this out?
		gameObject.SetActive(false);
	}

	private void HandleSwipe(VRInput.SwipeDirection dir) {
		if(gameObject.activeSelf) {
			switch(dir) {
				case VRInput.SwipeDirection.UP:	
					if(index > 0) { RenderImagesForIndex(--index); }
					break;
				
				case VRInput.SwipeDirection.DOWN:	
					if(index < maxIndex) { RenderImagesForIndex(++index); }
					break;
			}
		}
	}

	private void RenderImagesForIndex(int index) {		
		int numfiles = files.GetLength(0);
		
		// clear images
		var children = new List<GameObject>();
		foreach (Transform child in transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));

		// render images
		int start = index * IMAGES_PER_PAGE;
		int num = start + IMAGES_PER_PAGE > numfiles ? numfiles - start : IMAGES_PER_PAGE;
		for(int i = 0; i < num; i++) {
			Transform obj = (Transform) Instantiate(mediaThumbnailTemplate);
			Vector3 originalScale = obj.transform.localScale;	
			obj.transform.parent = transform;
			obj.transform.localPosition = new Vector3(-3f + 3f * (i/3), .2f, -3.5f + 3f * (i%3));
			obj.transform.rotation = new Quaternion(0,0,0,0);
			obj.transform.Rotate(0, 90, 0);
			obj.transform.localScale = originalScale;
			obj.GetComponent<MediaThumbnail>().SetTexture(files[start + i, 1]);
			obj.GetComponent<MediaThumbnail>().Initialize(files[start + i, 0]);
		}
	}
}
