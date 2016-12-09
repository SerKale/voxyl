using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils; // add this to deal with VR inputs

public class DragAndDroppable : MonoBehaviour {

	public  VRInteractiveItem m_InteractiveItem;
	public VRInput m_VrInput;
	
	private Transform m_Cam;
	private bool selected;
	private float distance;
	private float relativeSize;
	private Color tintColor = new Color(.5f,.5f,0,0);

    private float clickDelta = 0.6f;
    private bool click = false;
    private float clickTime;

	private void OnEnable ()
	{
		m_InteractiveItem.OnDoubleClick += HandleClick;
		m_VrInput.OnSwipe += HandleSwipe;
		m_Cam = Camera.main.transform;
		distance = Vector3.Distance(transform.position, m_Cam.position);
	}

	private void OnDisable ()
	{
		m_InteractiveItem.OnDoubleClick -= HandleClick;	
		m_VrInput.OnSwipe -= HandleSwipe;
	}	

	private void HandleClick() {
        click = false;
        selected = !selected;
        if (selected)
        {
            var renderer = GetComponent<Renderer>();
            renderer.material.color -= tintColor;
        }
        else
        {
            var renderer = GetComponent<Renderer>();
            renderer.material.color += tintColor;
        }
	}

	private void HandleSwipe(VRInput.SwipeDirection swipeDirection) {
		if(selected) {
			switch(swipeDirection) {
				case VRInput.SwipeDirection.UP:
					transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.3f, 1.3f, 1.3f));
					break;

				case VRInput.SwipeDirection.DOWN:
					transform.localScale = Vector3.Scale(transform.localScale, new Vector3(.7f, .7f, .7f));
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

		if (selected) {
			// follow gaze
			transform.position = m_Cam.position + (m_Cam.forward * distance);

			// computes angle of view between x and z planes
			double zxtangent = transform.position.z/transform.position.x;
			// computes tangent of angle of view between y and x planes, accounting for the 2pixel offset of camera
			double yxtangent = (transform.position.y-2) / transform.position.x;

			// Essentially, this says
			print("zxtangent: " + zxtangent);
			print("yxtangent: " + yxtangent);
			if (transform.position.x < 0 && transform.position.y < 0 && transform.position.z > 0 &&
				yxtangent > 0.6 && yxtangent < 1 && zxtangent < -.2 && zxtangent > -.7) {
				Destroy (gameObject);
			} 
			
			transform.LookAt(m_Cam);
			transform.Rotate(0, 180, 0); // Quad quirk
		}
	}
}
