using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class AddPhotoButton : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	public Transform m_Cam;


	public Transform imgTemplate;

	private float SCALE = 100F;

	private void OnEnable ()
	{
		m_InteractiveItem.OnClick += HandleClick;
	}

	private void OnDisable ()
	{
		m_InteractiveItem.OnClick -= HandleClick;
	}

	private void HandleClick() {
		// create cube and spawn
		print("Clicked");

		/*GameObject newCube = new GameObject("MyCube");
		newCube.AddComponent<MeshFilter>();
		newCube.AddComponent<BoxCollider>();
		newCube.AddComponent<MeshRenderer>();
		newCube.AddComponent<DragAndDroppable>();*/
		
		// create using prefab
		// DragAndDroppable img = Instantiate(Resources.Load("Prefabs/Image")) as DragAndDroppable;
		// img.m_Cam = m_Cam;
		// DragAndDroppable img = Resources.Load("Assets/Prefabs/Image") as DragAndDroppable;
		// img.m_Cam = Camera.main.transform;
		// print(img);
		// Instantiate(img);
		

		// CreateImage("Green");
	}

	public void CreateImage(string imgPath) {
		Transform obj = (Transform) Instantiate(imgTemplate, new Vector3(10, 10, 10), Quaternion.identity);

		var img = Resources.Load(imgPath, typeof(Texture2D)) as Texture2D;
		var renderer = obj.GetComponent<Renderer>();	
		renderer.material.mainTexture = img;
		// Image img = obj.GetComponent<Image>();
		// img.canvasRenderer.SetTexture(tex);*/
		
		// resize image
		obj.localScale = new Vector3(img.width / SCALE, img.height / SCALE, 1);
		
		// make image look at camera
		// obj.transform.localScale = new Vector3(1f, 1.2f, 1f);
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
