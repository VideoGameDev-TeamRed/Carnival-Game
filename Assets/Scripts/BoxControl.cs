using UnityEngine;
using System.Collections;

public class BoxControl : MonoBehaviour {

	public Rigidbody RB;
	// Use this for initialization
	void Start () {
		RB.isKinematic = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag.Equals("Ball")) {
			Debug.Log ("Hit");
			RB.isKinematic = true;
		}
			
	}
}
