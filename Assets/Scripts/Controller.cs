using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	private float x, z;
	public float speed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis ("Horizontal");
		z = Input.GetAxis ("Vertical");

		transform.position = transform.position + new Vector3 (x * speed, 0, z * speed);
	}
}
