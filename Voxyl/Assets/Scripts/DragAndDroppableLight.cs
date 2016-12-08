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
        }
    }
}
