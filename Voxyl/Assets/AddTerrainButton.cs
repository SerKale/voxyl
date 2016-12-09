using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class AddTerrainButton : MonoBehaviour {

	public GameObject m_terrainPanel;
	private VRInteractiveItem m_InteractiveItem;

	private void OnEnable ()
	{
		m_InteractiveItem.OnClick += HandleClick;
	}

	private void OnDisable ()
	{
		m_InteractiveItem.OnClick -= HandleClick;
	}

	private void HandleClick() {
		m_terrainPanel.SetActive(true);
	}

	void Awake () {
		m_InteractiveItem = GetComponent<VRInteractiveItem>();
	}

	// Use this for initialization
	void Start () {
		m_terrainPanel.SetActive(false);	
	}

	// Update is called once per frame
	void Update () {

	}
}
