using UnityEngine;
using System.Collections;
using com.teamred.carnivalgame;

public class CannonballBehaviour : MonoBehaviour {

	public float ShotForce { get; set; }

	public Transform CannonTransform { get; set; }

	// Use this for initialization
	void Start () {
		
		// Conforming cannonball to the actual firing apparatus's rotation
		this.gameObject.transform.rotation = CannonTransform.rotation;

		Vector3 shotVector = this.gameObject.transform.forward * ShotForce;

		this.gameObject.GetComponent<Rigidbody> ().AddForce (shotVector);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
