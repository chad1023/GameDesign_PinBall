using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Control : MonoBehaviour {
	public GameObject leftpad;
	public GameObject rightpad;
	private int stage;
	public int stagemax;
	public static int brickstate=1;
	public float turnSpeed;
	int left=0;
	int right = 0;
	public static int score = 0;
	public Text t;
	public Text timetext;
	public Text cleartext;
	float timetotal=0f;

	public GameObject nave;
	private Vector3 navestrat;
	private Vector3 naveend;

	public GameObject start;
	public GameObject prefab;
	public int velocity;
	static public int state=0;
	// Use this for initialization

	private GameObject ball;
	private Color colorStart;
	private Color colorEnd;
	private Renderer rend;
	public float duration;

	public GameObject[] hole;
	public static int holestate = -1;

	void Start () {
		stage = Application.loadedLevel + 1;
		print (stage);
		colorStart = prefab.GetComponent<Renderer> ().sharedMaterial.color;
		//print (colorStart);
		colorEnd = new Color (1.0f, colorStart.g, colorStart.b, 1.0f);
		//print (colorEnd);
		navestrat = nave.GetComponent<Transform> ().position;
		naveend = navestrat + new Vector3 (65, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (holestate != -1) {
			print (holestate);
			int index = holestate; 
			while (index == holestate) {
				index = Random.Range (0, hole.Length);
			}
			print ("index:" + index);

			Vector2 pos = Random.insideUnitCircle;
			Rigidbody r = ball.GetComponent<Rigidbody> ();
			ball.transform.position = hole[index].transform.position+new Vector3(pos.x,0,pos.y)*2f;
			if (r.velocity.magnitude < 15f) {
				Vector3 v = r.velocity.normalized;
				r.velocity = 10 * v;
			}
			holestate = -1;
		}

		if (Input.GetKeyDown (KeyCode.Z)&&left==0) {
			left = 1;

		}
		if (Input.GetKeyDown (KeyCode.X)&&right==0) {
			right = 1;
		}
		if(state==0&&Input.GetKeyDown(KeyCode.Space)){
			Vector3 pos = start.transform.position;
			ball=(GameObject)Instantiate(prefab,pos,Quaternion.identity);
			ball.GetComponent<Rigidbody> ().velocity = new Vector3(0,0,velocity);
			rend = ball.GetComponent<Renderer> ();
			timetotal = 0f;
			state = 1;
		}
		if (state == 1) {
			timetotal += Time.deltaTime;
			t.text = "Score:" + score;
			timetext.text = "Time:" + timetotal;

			if (timetotal > 3f) {
				float lerp = Mathf.PingPong(Time.time, duration) / duration;
				rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);

				nave.transform.position = Vector3.Lerp (navestrat, naveend, lerp);

			}
			if (timetotal >= 3f + duration) {
				cleartext.text = "Clear!!!";
			}
		}
		if(Input.GetKeyDown(KeyCode.A)){
			next();
		}
	}
	void FixedUpdate(){
		if (left !=0) {
			Transform t = leftpad.GetComponent<Transform> ();
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
		Transform t2 = rightpad.GetComponent<Transform> ();
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
	public void next(){
		print ("click");
		print (stage);
		if (stage < stagemax) {
			stage++;
			state = 0;
			Application.LoadLevel ("Scene"+stage);
		}
	}
}