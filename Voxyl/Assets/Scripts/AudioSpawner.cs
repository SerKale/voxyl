using UnityEngine;
using System.Collections;

public class AudioSpawner : MonoBehaviour {

	public Transform audioTemplate;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateAudio(string url) {	
        Transform obj = (Transform)Instantiate(audioTemplate, new Vector3(3, 3, 3), Quaternion.identity);
		var audio = obj.GetComponent<AudioSource>();	
		audio.clip = (AudioClip) Resources.Load("_Audio/" + url);
		audio.Play();
	}
}
