using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils; // add this to deal with VR inputs

public class DragAndDroppable : MonoBehaviour {

	private bool selected;
	private float distance;
	private float relativeSize;

   	// For these serialize field things, I think you also have to make them a thing in the Scene editor?
	public  VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.
	// public Transform m_Cam;
	private Transform m_Cam;
	public VRInput m_VrInput;

	private bool m_GazeOver;

	private Color tintColor = new Color(.5f,.5f,0,0);

	private void OnEnable ()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_InteractiveItem.OnClick += HandleClick;

		m_VrInput.OnSwipe += HandleSwipe;

		m_Cam = Camera.main.transform;

		distance = Vector3.Distance(transform.position, m_Cam.position);
		// relativeSize = ;
	}

	private void OnDisable ()
	{
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		m_InteractiveItem.OnClick -= HandleClick;
		
		m_VrInput.OnSwipe -= HandleSwipe;
		// m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
	}

	private void HandleOver() {
		m_GazeOver = true;
		// Debug.Log("Looking at it!");
	}

	private void HandleOut() {
		m_GazeOver = false;	
		// print("Not looking at it!");
	}

	private void HandleClick() {
		selected = !selected;
		print("Object " + (selected ? "selected" : "un-selected"));
		// print(halo.Size);
		// print("about to delete!");
		// Destroy (gameObject);
		if(selected) {
			var renderer = GetComponent<Renderer>();
			print(renderer.material.color);
			renderer.material.color -= tintColor;
		} else {	
			var renderer = GetComponent<Renderer>();
			renderer.material.color += tintColor;
		}
	}

	private void HandleSwipe(VRInput.SwipeDirection swipeDirection) {
		if(selected) {
			switch(swipeDirection) {
				case VRInput.SwipeDirection.UP:
					transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.1f, 1.1f, 1.1f));
					break;

				case VRInput.SwipeDirection.DOWN:
					transform.localScale = Vector3.Scale(transform.localScale, new Vector3(.9f, .9f, .9f));
					break;
				
				case VRInput.SwipeDirection.LEFT:
					distance += 1f;
					break;

				case VRInput.SwipeDirection.RIGHT:
					distance -= 1f;
					break;
			}
		}
	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// transform.Rotate(1,1,1);
		if (selected) {
			print ("moving");
			// follow gaze
			transform.position = m_Cam.position + (m_Cam.forward * distance);

			// computes angle of view between x and z planes
			double zxtangent = transform.position.z/transform.position.x;
			// computes tangent of angle of view between y and x planes, accounting for the 2pixel offset of camera
			double yxtangent = (transform.position.y-2) / transform.position.x;
			if (transform.position.x < 0 && transform.position.y < 0 && transform.position.z > 0 &&
				yxtangent > 0.6 && yxtangent < 1 && zxtangent < -.2 && zxtangent > -.7) {
				Destroy (gameObject);
			} 
			// transform.localScale = new Vector3(relativeSize, relativeSize, relativeSize);
			transform.LookAt(m_Cam);
			transform.Rotate(0, 180, 0); // Quad quirk
		}
	}
}
