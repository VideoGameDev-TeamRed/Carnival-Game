using UnityEngine;
using System.Collections;
using com.teamred.carnivalgame;

public class CannonballBehaviour : MonoBehaviour {

	public float ShotForce { get; set; }

	// Use this for initialization
	void Start () {
		// Rotates ball before shooting to compensate for angle of barrel
		this.gameObject.transform.Rotate (new Vector3 (0, 0, -25.0f));

		Vector3 shotVector = -this.gameObject.transform.right * ShotForce;

		this.gameObject.GetComponent<Rigidbody> ().AddForce (shotVector);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
