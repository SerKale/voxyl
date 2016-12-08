using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class AddAudioButton : MonoBehaviour
{
    public VRInteractiveItem m_InteractiveItem;
	public GameObject m_AudioPanel;

    private void OnEnable()
    {
        m_InteractiveItem.OnClick += HandleClick;
    }

    private void OnDisable()
    {
        m_InteractiveItem.OnClick -= HandleClick;
    }

    private void HandleClick()
    {
		m_AudioPanel.SetActive(true);
    }

    // Use this for initialization
    void Start()
    {	
		m_AudioPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
