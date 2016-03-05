using UnityEngine;
using System.Collections;

public class EachObject : MonoBehaviour {

	public Rigidbody RB;

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
		if (other.transform.name.Contains("Projectile")) {
			Debug.Log ("Hit");
			RB.isKinematic = false;
		}
	}

}
