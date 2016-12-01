using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimerUntilNextScene : MonoBehaviour {

	public float countdown = 5f;
	public string nextName;

	void FixedUpdate () 
	{
		countdown -= Time.fixedDeltaTime;
		if (countdown <= 0f) {
			SceneManager.LoadScene(nextName, LoadSceneMode.Single);
		}
	}
}
