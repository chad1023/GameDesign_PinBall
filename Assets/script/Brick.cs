using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {	
	public GameObject brick;
	public GameObject brick2;
	public int turn;
	public float v;

	public float high,low;


	
	// Update is called once per frame
	void FixedUpdate () {
		if (Control.brickstate == turn) {
			Transform t = brick.GetComponent<Transform> ();
			if (brick.transform.position.y < high) {
				t.position = new Vector3(t.position.x,t.position.y+v * Time.deltaTime,t.position.z);
			}

			 t = brick2.GetComponent<Transform> ();
			if (brick2.transform.position.y > low) {
				t.position = new Vector3(t.position.x,t.position.y-v * Time.deltaTime,t.position.z);
			}


			}
	
		}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Control.brickstate=turn;
		}
	}
}
