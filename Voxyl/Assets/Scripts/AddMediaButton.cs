using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class AddMediaButton : MonoBehaviour {
	
	public GameObject m_MediaPanel;
	public VRInteractiveItem m_InteractiveItem;

	private void OnEnable ()
	{
		m_InteractiveItem.OnClick += HandleClick;
	}

	private void OnDisable ()
	{
		m_InteractiveItem.OnClick -= HandleClick;
	}

	private void HandleClick() {
		m_MediaPanel.SetActive(true);
	}
	
	// Use this for initialization
	void Start () {
		m_MediaPanel.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
