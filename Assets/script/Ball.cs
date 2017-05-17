using UnityEngine;
using System.Collections;


public class Ball : MonoBehaviour {
	public int vmax;
	public GameObject hitprefab;
	private Rigidbody r;
	public GameObject dieanimate;

	// Use this for initialization
	void Start () {
		//transform.position = start.GetComponent<Transform>().position;
		//GetComponent<Rigidbody> ().velocity = new Vector3(0,0,velocity);
		r=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (r.velocity.magnitude < 0.1f) {
			print ("die");
			Instantiate (dieanimate);

			Control.state = 0;
			Control.score -= 1000;
			Destroy (gameObject);
		}		
	
	}
	void OnCollisionEnter(Collision collision){
	
		if (collision.gameObject.layer == 0) {
			Vector3 pos = collision.contacts[0].point;

			GameObject hit = (GameObject)Instantiate (hitprefab, pos, Quaternion.identity);
			Vector3 v = Vector3.Reflect (-1*collision.relativeVelocity, collision.contacts [0].normal);
			if (v.magnitude * 1.05f >= vmax) {
				v = v.normalized * vmax;
			} 
			else {
				v *= 1.05f;
			}
			GetComponent<Rigidbody> ().velocity = v;
			Control.score += 10;
		
		}


	
	}
}
