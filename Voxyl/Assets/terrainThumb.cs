using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class terrainThumb : MonoBehaviour {

	private VRInteractiveItem m_InteractiveItem;
	public GameObject terrain;
	public Transform parent;

	private void OnEnable() {
		m_InteractiveItem.OnClick += HandleClick;
	}

	private void OnDisable() {
		m_InteractiveItem.OnClick -= HandleClick;
	}	

	private void HandleClick() {	
		foreach (Transform child in parent) {
			child.gameObject.SetActive(false);
		}

		if (terrain) { terrain.SetActive(true); }

		transform.parent.gameObject.SetActive(false);
	}

	// Use this for initialization
	void Awake () {	
		m_InteractiveItem = GetComponent<VRInteractiveItem>();
	}
}
