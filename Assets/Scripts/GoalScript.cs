using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	public float speed = 15f;
	private Rigidbody rigidBody;
	public GameObject pedestal;
	public GameObject objectOne;
	public GameObject objectTwo;
	public GameObject objectThree;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.AddForce (-speed, 0, 0);
		objectOne = objectOne.GetComponent<GameObject> ();
		objectTwo = objectTwo.GetComponent<GameObject> ();
		objectThree = objectThree.GetComponent<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (pedestal.transform.position.x < -5.5) {
			pedestal.transform.position = new Vector3 (3.69f, 0.62f, -2.22f);
			objectOne.transform.position = new Vector3 (-0.3960004f, -0.07200018f, 1.25f);
			objectTwo.transform.position = new Vector3 (0.3119998f, -0.07200018f, 1.248f);
			objectThree.transform.position = new Vector3 (-0.05200005f, -0.07200024f, 1.72f);
		}
	}
}
