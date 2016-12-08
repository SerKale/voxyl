using UnityEngine;
using System.Collections;

public class TextWrap : MonoBehaviour {
	private Renderer r;
	private TextMesh tm;
	public float width;

	// Use this for initialization
	void Start () {
		/*r = GetComponent<MeshRenderer>();
		tm = GetComponent<TextMesh>();
		tm.text = "";*/
		// SizeToFit("This is the rhythm of the night");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Initialize() {
		r = GetComponent<MeshRenderer>();
		tm = GetComponent<TextMesh>();
		tm.text = "";
	}

	public void SizeToFit(string remainder) {
		string keep = FindChopPoint(remainder);
		tm.text += keep;
		if(keep == remainder) { return; } // we've chopped as much as we can
		string nextline = remainder.Substring(keep.Length+1);
		tm.text += "\n";
		SizeToFit(nextline);
	}

	// returns the part of the string to keep	
	private string FindChopPoint(string s) {
		int pos = s.LastIndexOf(" ");
		if(pos == -1) {
			return s;
		}
		string curr = s.Substring(0, pos);
		// string remainder = s.Substring(pos+1, s.Length-pos);
		string saved = tm.text;
		tm.text += "\n" + curr;
		if(r.bounds.extents.z > width) {
			tm.text = saved;
			return FindChopPoint(curr);
		} else {
			tm.text = saved;
			return curr;
		}
	}
}
