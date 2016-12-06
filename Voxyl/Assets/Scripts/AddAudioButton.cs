using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class AddAudioButton : MonoBehaviour
{

    [SerializeField]
    private VRInteractiveItem m_InteractiveItem;
    public Transform m_Cam;


    public Transform imgTemplate;

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
        Transform obj = (Transform)Instantiate(imgTemplate, new Vector3(3, 3, 3), Quaternion.identity);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
