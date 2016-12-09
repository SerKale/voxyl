using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils; // add this to deal with VR inputs

public class DragAndDroppableLight : MonoBehaviour
{
	public VRInteractiveItem m_InteractiveItem;
    public VRInput m_VrInput;
	
	private bool selected;
    private float distance;
	private Transform m_Cam;

    private void OnEnable()
    {
        m_InteractiveItem.OnClick += HandleClick;
        m_VrInput.OnSwipe += HandleSwipe;
        m_Cam = Camera.main.transform;
        distance = Vector3.Distance(transform.position, m_Cam.position);
    }

    private void OnDisable()
    {
        m_InteractiveItem.OnClick -= HandleClick;
        m_VrInput.OnSwipe -= HandleSwipe;
    } 

    private void HandleClick()
    {
        selected = !selected;
    }

    private void HandleSwipe(VRInput.SwipeDirection swipeDirection)
    {
        if (selected)
        {
            switch (swipeDirection)
            {
                case VRInput.SwipeDirection.UP:
                    GetComponent<Light>().intensity += .5f;
                    break;

                case VRInput.SwipeDirection.DOWN:
                    GetComponent<Light>().intensity -= .5f;
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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            // follow gaze
            transform.position = m_Cam.position + m_Cam.forward * distance;

			// computes angle of view between x and z planes
			double zxtangent = transform.position.z/transform.position.x;
			// computes tangent of angle of view between y and x planes, accounting for the 2pixel offset of camera
			double yxtangent = (transform.position.y-2) / transform.position.x;

			// If curious (ie last name bertrand), READ:
			// Essentially, zx tangent and yx tangent give you an idea of the angle of the viewer.
			// zxtangent is for the viewer's left<->right view
			// yxtangent is for the viewer's up<->down view 
			// The ranges below are associated with the angle of view where the viewer is looking 
			// at the trash can view in the current menu. If the menu is changed, these must change too!
			print("zxtangent: " + zxtangent);
			print("yxtangent: " + yxtangent);
			if (transform.position.x < 0 && transform.position.y < 0 && transform.position.z > 0 &&
				yxtangent > 0.6 && yxtangent < 1 && zxtangent < -.2 && zxtangent > -.7) {
				Destroy (gameObject);
			} 
        }
    }
}
