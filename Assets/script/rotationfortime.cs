using UnityEngine;
using System.Collections;

public class rotationfortime: MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Control.state != 0) {
			transform.Rotate (Vector3.forward * Time.deltaTime*speed);
		}
		
	
	}
}
