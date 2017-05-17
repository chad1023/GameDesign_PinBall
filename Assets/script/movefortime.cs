using UnityEngine;
using System.Collections;

public class movefortime : MonoBehaviour {

	public float dx;
	public float dz;
	private Vector3 start=new Vector3();

	// Use this for initialization
	void Start () {
		start = transform.position;
		print (start);
	
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 v = new Vector3 ();
		if (dx == 0f) {
			v = new Vector3 (0, 0, Mathf.PingPong (Time.time, dz));

		} 
		else if (dz == 0) {
			v = new Vector3 (Mathf.PingPong (Time.time, dx), 0, 0);
		} 
		else {
			v = new Vector3 (Mathf.PingPong (Time.time, dx), 0, Mathf.PingPong (Time.time, dz));
		}
		if (dx < 0f || dz < 0f) {

			transform.position = start - v;
		} else {
			transform.position = start + v;
		}
	
	}
}
