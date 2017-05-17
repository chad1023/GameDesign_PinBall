using UnityEngine;
using System.Collections;

public class Blackhole : MonoBehaviour {
	private int index;
	// Use this for initialization
	void Start () {
		string s = name;
		s = s.Substring (9);
		print(s);
		index=int.Parse (s);

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerExit(Collider c){
		if (c.gameObject.tag == "Player") {
			Control.holestate = index;
			print ("hole");
		}
	}
}
