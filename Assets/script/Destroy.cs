using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	public GameObject dieanimate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Instantiate (dieanimate);
			Destroy (other.gameObject);
			Control.state = 0;
			Control.score -= 1000;
		}
	}
}
