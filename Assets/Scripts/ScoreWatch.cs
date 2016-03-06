using UnityEngine;
using System.Collections;

public class ScoreWatch : MonoBehaviour {

	public static int P1_ObjectsLeft = 3;
	public static int P2_ObjectsLeft = 3;
	public static int P3_ObjectsLeft = 3;
	public static int P4_ObjectsLeft = 3;
	public static int P5_ObjectsLeft = 3;

	public static bool ObjectsGone;
	public UIScript uiCanvas;

	// Use this for initialization
	void Start () {
		
		ObjectsGone = false;

	}

	// Update is called once per frame
	void Update () {

		if (ObjectsGone == false) {
			ObjectsGone = true;
	
			if (P1_ObjectsLeft == 0) {
				Debug.Log ("No objects left on platform1");
				Debug.Log ("Score Increase?");
				uiCanvas.UpdateScore ();
				P1_ObjectsLeft = 3;
			}

			if (P2_ObjectsLeft == 0) {
				Debug.Log ("No objects left on platform2");
				Debug.Log ("Score Increase?");
				uiCanvas.UpdateScore ();
				P2_ObjectsLeft = 3;
			}
			if (P3_ObjectsLeft == 0) {
				Debug.Log ("No objects left on platform3");
				Debug.Log ("Score Increase?");
				uiCanvas.UpdateScore ();
				P3_ObjectsLeft = 3;
			}
			if (P4_ObjectsLeft == 0) {
				Debug.Log ("No objects left on platform4");
				Debug.Log ("Score Increase?");
				uiCanvas.UpdateScore ();
				P4_ObjectsLeft = 3;
			}
			if (P5_ObjectsLeft == 0) {
				Debug.Log ("No objects left on platform5");
				Debug.Log ("Score Increase?");
				uiCanvas.UpdateScore ();
				P5_ObjectsLeft = 3;
			}
		}

	}
}
