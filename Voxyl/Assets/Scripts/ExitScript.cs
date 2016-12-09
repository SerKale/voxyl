using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class ExitScript : MonoBehaviour {

	public string m_NextScene;
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
		print ("Clicked!");
		Application.LoadLevel (m_NextScene);
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}
}
