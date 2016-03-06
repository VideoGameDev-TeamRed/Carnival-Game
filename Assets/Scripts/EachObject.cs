using UnityEngine;
using System.Collections;

public class EachObject : MonoBehaviour {

	public Rigidbody RB;
	private Vector3 vel;
	public static float score = 0;

	public GameObject Platform;
	public bool KnockedOff = false;
	public AudioSource sourceOne;
	// Use this for initialization
	void Start () {
		RB.isKinematic = true;
		sourceOne = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
			
		if ((this.transform.position.y < Platform.transform.position.y) && KnockedOff==false) {

			KnockedOff = true;

			if (Platform.tag.Equals ("1")) {
				ScoreWatch.P1_ObjectsLeft = ScoreWatch.P1_ObjectsLeft - 1;
				Debug.Log ("An object from P1 was knocked off");
			}
			if (Platform.tag.Equals ("2")) {
				ScoreWatch.P2_ObjectsLeft = ScoreWatch.P2_ObjectsLeft - 1;
				Debug.Log ("An object from P2 was knocked off");
			}
			if (Platform.tag.Equals ("3")) {
				ScoreWatch.P3_ObjectsLeft = ScoreWatch.P3_ObjectsLeft - 1;
				Debug.Log ("An object from P3 was knocked off");
			}

			if (Platform.tag.Equals ("4")) {
				ScoreWatch.P4_ObjectsLeft = ScoreWatch.P4_ObjectsLeft - 1;
				Debug.Log ("An object from P4 was knocked off");
			}

			if (Platform.tag.Equals ("5")) {
				ScoreWatch.P5_ObjectsLeft = ScoreWatch.P5_ObjectsLeft - 1;
				Debug.Log ("An object from P5 was knocked off");
			}

		}
	}

	void OnCollisionEnter(Collision other)
	{
		//NEED TO CHANGE NAME TO WHATEVER PROJECTILE IS NAMED
		if (other.transform.tag.Equals("Ball")) {
			Debug.Log ("Hit");
			RB.isKinematic = false;
			vel =	RB.gameObject.GetComponent<Rigidbody> ().velocity;
			sourceOne.Play ();

			RB.AddForce (vel/300);

		}
	}

}
