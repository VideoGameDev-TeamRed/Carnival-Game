using UnityEngine;
using System.Collections;
using com.teamred.carnivalgame;
using System.Threading;

[RequireComponent(typeof(GameObject))]
public class Cannon : IRotateable, IShootable {

	private GameObject CannonObject;

	private float ReloadTime;

	public bool IsLoaded { get; set; }

	private const float BALL_TIME = 10.0f;

	public Cannon(GameObject cannonObject) {
		this.CannonObject = cannonObject;
		this.IsLoaded = true;
	}

	public void Rotate (float turnSpeed) {
		CannonObject.transform.Rotate(new Vector3(0, turnSpeed, 0));
	}

	public void Fire (float shotForce) {
		IsLoaded = false;

		GameObject cannonBall = (GameObject) GameObject.Instantiate 
			(Resources.Load("Prefabs/Cannonball"), CannonObject.transform.position, CannonObject.transform.rotation);
		cannonBall.GetComponent<CannonballBehaviour> ().ShotForce = shotForce;
		GameObject.Destroy (cannonBall, BALL_TIME); 
	}

	public IEnumerator Reload (float timeToReload) {
		// Wait for timeToReload
		yield return new WaitForSeconds(timeToReload);
		IsLoaded = true;
	}
}
