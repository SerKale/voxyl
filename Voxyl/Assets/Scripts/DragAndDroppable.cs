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

	private void OnEnable ()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_InteractiveItem.OnClick += HandleClick;

		m_VrInput.OnSwipe += HandleSwipe;

		m_Cam = Camera.main.transform;

		distance = Vector3.Distance(transform.position, m_Cam.position);
		relativeSize = 1f;
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
		if(selected) {
			var renderer = GetComponent<Renderer>();
			print(renderer.material.color);
			// renderer.material.color -= new Color(0,0,0,.5f);
		} else {	
			var renderer = GetComponent<Renderer>();
			// renderer.material.color += .5f;
		}
		// print(transform.position.x);
		// print(
	}

	private void HandleSwipe(VRInput.SwipeDirection swipeDirection) {
		if(selected) {
			switch(swipeDirection) {
				case VRInput.SwipeDirection.UP:
					relativeSize += .3f;
					break;

				case VRInput.SwipeDirection.DOWN:
					relativeSize -= .3f;
					break;
				
				case VRInput.SwipeDirection.LEFT:
					distance += 1f;
					break;

				case VRInput.SwipeDirection.RIGHT:
					distance -= 1f;
					break;
			}
			// print("Size is now at " + relativeSize);
		}
	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
			// follow gaze
			transform.position = m_Cam.position + m_Cam.forward * distance;
			transform.localScale = new Vector3(relativeSize, relativeSize, relativeSize);
		}
	}
}
