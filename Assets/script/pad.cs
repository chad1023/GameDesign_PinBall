using UnityEngine;
using System.Collections;

public class pad : MonoBehaviour {
	private int left=0;
	private int right=0;
	public GameObject leftpad2;
	public GameObject rightpad2;
	public float turnSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)&&left==0) {
			left = 1;

		}
		if (Input.GetKeyDown (KeyCode.X)&&right==0) {
			right = 1;
		}
	
	}
	void FixedUpdate(){
		if (left !=0) {
			Transform t = leftpad2.GetComponent<Transform> ();
			if (left == 1) 
			{
				t.rotation *= Quaternion.Euler (0.0f, -1f * turnSpeed, 0.0f);
				if (t.rotation == Quaternion.Euler (0.0f, -60f, 0.0f)) 
				{
					left++;
				}
			} 
			else 
			{
				t.rotation *= Quaternion.Euler (0.0f, 1f * turnSpeed, 0.0f);
				if (t.rotation == Quaternion.Euler (0.0f, 0.0f, 0.0f)) {
					left = 0;

				}
			}

		}
		if (right !=0) {
			Transform t2 = rightpad2.GetComponent<Transform> ();
			if (right == 1) 
			{
				t2.rotation *= Quaternion.Euler (0.0f, 1f * turnSpeed, 0.0f);
				if (t2.rotation == Quaternion.Euler (0.0f, 60f, 0.0f)) 
				{
					right++;
				}
			} 
			else 
			{
				t2.rotation *= Quaternion.Euler (0.0f, -1f * turnSpeed, 0.0f);
				if (t2.rotation == Quaternion.Euler (0.0f, 0.0f, 0.0f)) {
					right = 0;

				}
			}

		}
	}
}
