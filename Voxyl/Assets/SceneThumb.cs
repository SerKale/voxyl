using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;

public class SceneThumb : MonoBehaviour {

	private VRInteractiveItem m_InteractiveItem;
	public string toLoad;

	private void OnEnable() {
		m_InteractiveItem.OnClick += HandleClick;
	}

	private void OnDisable() {
		m_InteractiveItem.OnClick -= HandleClick;
	}	

	private void HandleClick() {	
		SceneManager.LoadScene(toLoad, LoadSceneMode.Single);
	}

	// Use this for initialization
	void Awake () {	
		m_InteractiveItem = GetComponent<VRInteractiveItem>();
	}
}
