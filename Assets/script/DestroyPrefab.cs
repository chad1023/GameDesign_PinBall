using UnityEngine;
using System.Collections;

public class DestroyPrefab : MonoBehaviour {
	private float time=0f;
	public float lifetime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (time < lifetime) {
			time += Time.deltaTime;
		} 
		else {
			time = 0f;
			Destroy (gameObject);
		}
		
	
	}
}
