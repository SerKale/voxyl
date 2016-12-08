using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class AddPhotoButton : MonoBehaviour {

	public Transform m_Cam;
	public Transform imgTemplate;

	private float SCALE = 100F;

	public void CreateImage(string imgPath) {
		Transform obj = (Transform) Instantiate(imgTemplate, new Vector3(10, 10, 10), Quaternion.identity);

		var img = Resources.Load(imgPath, typeof(Texture2D)) as Texture2D;
		var renderer = obj.GetComponent<Renderer>();	
		renderer.material.mainTexture = img;
		
		// resize image
		obj.localScale = new Vector3(img.width / SCALE, img.height / SCALE, 1);
		
		// make image look at camera
		obj.LookAt(m_Cam);
		obj.Rotate(0, 180, 0);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
