using UnityEngine;
using System.Collections;

public class EachObject : MonoBehaviour {

	public Rigidbody RB;
	private Vector3 vel;
	public static float score = 0;
	// Use this for initialization
	void Start () {
		RB.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
			
			
	}

	void OnCollisionEnter(Collision other)
	{
		//NEED TO CHANGE NAME TO WHATEVER PROJECTILE IS NAMED
		if (other.transform.tag.Equals("Ball")) {
			Debug.Log ("Hit");
			RB.isKinematic = false;

			vel =	RB.gameObject.GetComponent<Rigidbody>().velocity;

			RB.AddForce (vel);

		}
	}

}
