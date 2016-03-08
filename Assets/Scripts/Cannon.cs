using UnityEngine;
using System.Collections;
using com.teamred.carnivalgame;
using System.Threading;

[RequireComponent(typeof(GameObject))]
public class Cannon : IRotateable, IShootable {

	private GameObject CannonObject;

	private float ReloadTime;

	public bool IsLoaded { get; set; }

	private const float BALL_TIME = 2f;

	public Cannon(GameObject cannonObject) {
		this.CannonObject = cannonObject;
		this.IsLoaded = true;
	}

	public void RotateHorizontal (float turnSpeed) {
		CannonObject.transform.Rotate(new Vector3(0, turnSpeed, 0));
	}

	public void RotateVertical (float turnSpeed) {
		//Debug.Log ("Rotating vertically");

		// Finds the subview of the Cannon that is the cylinder.
		// This Script is to be used with the lCannon prefab, so Cylinder will never be null.
		Transform cylinder = CannonObject.transform.Find("Cannon/Cylinder");

		Vector3 eulerAngles = cylinder.eulerAngles;
		Debug.Log ("x: " + eulerAngles.x + ",y: " + eulerAngles.y + ",z: " + eulerAngles.z);


		if (eulerAngles.x >= 300 && eulerAngles.x <= 355) {
			cylinder.Rotate (new Vector3 (0, turnSpeed, 0));
		}

		if (eulerAngles.x >= 355 && turnSpeed > 0) {
			cylinder.Rotate (new Vector3 (0, turnSpeed, 0));
		}

		if (eulerAngles.x <= 300 && turnSpeed < 0) {
			cylinder.Rotate (new Vector3 (0, turnSpeed, 0));
		}
	}

	public void Fire (float shotForce) {
		IsLoaded = false;

		Transform cannonTransform = CannonObject.transform.Find("Cannon/Cylinder");

		GameObject cannonBall = (GameObject) GameObject.Instantiate 
			(Resources.Load("Prefabs/Cannonball"), CannonObject.transform.position, CannonObject.transform.rotation);
		cannonBall.GetComponent<CannonballBehaviour> ().ShotForce = shotForce;
		cannonBall.GetComponent<CannonballBehaviour> ().CannonTransform = cannonTransform;
		GameObject.Destroy (cannonBall, BALL_TIME); 
	}

	public IEnumerator Reload (float timeToReload) {
		// Wait for timeToReload
		yield return new WaitForSeconds(timeToReload);
		IsLoaded = true;
	}
}
