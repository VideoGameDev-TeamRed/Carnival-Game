using UnityEngine;
using System.Collections;

public class BlockSpawn : MonoBehaviour {


	public float Speed = 0.025f;
	public float DistanceAllowed = -5.75f;
	public GameObject Pyramid;
	public Vector3 OriginPosition;
	private Quaternion OriginRotation;
	public bool CanClone;

	// Use this for initialization
	void Start () {
		CanClone = true;

		//LINE TO DETERMINE WHERE PYRAMIDS START, CHANGE TO WHATEVER IT NEEDS TO BE
		OriginPosition = new Vector3 (19.5f, 0.59f, -2.207f);

		//OriginRotation = Quaternion.Euler (-90, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		//The following if statement instantiates a new pyramid chain
		if (CanClone && this.transform.position.x < 4.5f) {
			CanClone = false;
			GameObject PyramidsClone = (GameObject) Instantiate 
				(Pyramid, OriginPosition, OriginRotation);
		}

		//The following if statement keeps there from being unlimited chains of pyramids
		if (this.transform.position.x < DistanceAllowed) {
			Destroy (this.gameObject);

			if (this.transform.tag.Equals ("1")) {
				ScoreWatch.P1_ObjectsLeft = 3;
			}
			if (this.transform.tag.Equals ("2")) {
				ScoreWatch.P2_ObjectsLeft = 3;
			}
			if (this.transform.tag.Equals ("3")) {
				ScoreWatch.P3_ObjectsLeft = 3;
			}
			if (this.transform.tag.Equals ("4")) {
				ScoreWatch.P4_ObjectsLeft = 3;
			}
			if (this.transform.tag.Equals ("5")) {
				ScoreWatch.P5_ObjectsLeft = 3;
			}
		}

	}

	void FixedUpdate(){
		//This sets the speed of the pyramid chain
		this.transform.position = this.transform.position - new Vector3 (Speed, 0, 0);
	}

}
