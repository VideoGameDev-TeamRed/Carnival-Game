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

		Transform cylinder = CannonObject.transform.Find("Cannon/Cylinder");
		Vector3 eulerAngles = cylinder.eulerAngles;

		Debug.Log ("x: " + eulerAngles.x + ",y: " + eulerAngles.y + ",z: " + eulerAngles.z);

//		Quaternion rotationQuat = Quaternion.Euler (turnSpeed, 0f, 0f);
//
//		rotationQuat = this.ClampRotationAroundYAxis (rotationQuat, 300f, 355f);
//
//		cylinder.localRotation = rotationQuat;

//		if (eulerAngles.y >= 120 && eulerAngles.y <= 240) {
//			//cylinder.Rotate (new Vector3 (turnSpeed, 0, 0));
//			CannonObject.transform.Rotate(new Vector3(0, turnSpeed, 0));
//		}
//
//		if (eulerAngles.y >= 240 && turnSpeed < 0) {
//			//cylinder.Rotate (new Vector3 (turnSpeed, 0, 0));
//			CannonObject.transform.Rotate(new Vector3(0, turnSpeed, 0));
//		}
//
//		if (eulerAngles.y <= 120 && turnSpeed > 0) {
//			//cylinder.Rotate (new Vector3 (turnSpeed, 0, 0));
//			CannonObject.transform.Rotate(new Vector3(0, turnSpeed, 0));
//		}

		CannonObject.transform.Rotate(new Vector3(0, turnSpeed, 0));
	}

	public void RotateVertical (float turnSpeed) {
		//Debug.Log ("Rotating vertically");

		// Finds the subview of the Cannon that is the cylinder.
		// This Script is to be used with the lCannon prefab, so Cylinder will never be null.
		Transform cylinder = CannonObject.transform.Find("Cannon/Cylinder");
//
//		float angle = Mathf.Clamp (turnSpeed, -180, 180);
//
//		cylinder.localEulerAngles = new Vector3 (cylinder.localEulerAngles.x, cylinder.localEulerAngles.y, angle);

//		Vector3 angle = cylinder.localEulerAngles;
//		angle.x = Mathf.Clamp(angle.x * Input.GetAxis("Mouse Y"), 0.0f, -50.0f);
//		Debug.Log ("X: " + angle.x);
//		cylinder.localEulerAngles = angle;

//		Quaternion rotationQuat = cylinder.localRotation;
//		rotationQuat *= Quaternion.Euler (0f, turnSpeed, 0f);
//
//		rotationQuat = ClampRotationAroundYAxis (rotationQuat, 300, 355);
		//rotationZ = Mathf.Clamp (rotationZ, -90, 90);

		//rotationQuat = this.ClampRotationAroundYAxis (rotationQuat, 300f, 355f);

		//cylinder.localRotation = rotationQuat;
		//Debug.Log ("x: " + eulerAngles.x + ",y: " + eulerAngles.y + ",z: " + eulerAngles.z);


//		if (eulerAngles.x >= 300 && eulerAngles.x <= 355) {
//			cylinder.Rotate (new Vector3 (0, turnSpeed, 0));
//		}
//
//		if (eulerAngles.x >= 355) {
//			//cylinder.Rotate (new Vector3 (0, turnSpeed, 0));
//			eulerAngles.x = 349.999f;
//			cylinder.eulerAngles = eulerAngles;
//		}
//
//		if (eulerAngles.x <= 300) {
//			//cylinder.Rotate (new Vector3 (0, turnSpeed, 0));
//			eulerAngles.x = 300.0001f;
//			cylinder.eulerAngles = eulerAngles;
//		}
		cylinder.Rotate (new Vector3 (0, turnSpeed, 0));
		//rigid.MoveRotation (Quaternion.EulerAngles (cylinder.eulerAngles));
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

	private float ClampAngle(float angle, float min, float max) {

		if (angle<90 || angle>270){       // if angle in the critic region...
			if (angle>180) angle -= 360;  // convert all angles to -180..+180
			if (max>180) max -= 360;
			if (min>180) min -= 360;
		}    
		angle = Mathf.Clamp(angle, min, max);
		if (angle<0) angle += 360;  // if angle negative, convert to 0..360
		return angle;
	}

	private Quaternion ClampRotationAroundYAxis(Quaternion q, float min, float max)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;

		float angleY = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

		angleY = Mathf.Clamp (angleY, min, max);

		q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleY);

		return q;
	}
}
