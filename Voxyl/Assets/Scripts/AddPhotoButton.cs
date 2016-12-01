using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class AddPhotoButton : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	public Transform m_Cam;


	public Transform imgTemplate;

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
		

		CreateImage("Green");
	}

	public void CreateImage(string tag) {
		Transform obj = (Transform) Instantiate(imgTemplate, new Vector3(3, 3, 3), Quaternion.identity);
		var renderer = obj.GetComponent<Renderer>();
		Color color;
		print(tag);
		switch(tag) {
			case "White":
				color = Color.white;
				break;

			case "Red":
				color = Color.red;
				break;

			case "Green":
				color = Color.green;
				break;

			case "Blue":
				color = Color.blue;
				break;

			case "Black":
				color = Color.black;
				break;

			default:
				color = Color.red;
				break;
		}
		renderer.material.color = color;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
