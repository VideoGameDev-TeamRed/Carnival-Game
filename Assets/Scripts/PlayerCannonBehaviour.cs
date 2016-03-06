using UnityEngine;
using System.Collections;
using com.teamred.carnivalgame;
using System;

public class PlayerCannonBehaviour : MonoBehaviour {

	private Cannon PlayerCannon;

	[SerializeField]
	private float RotateSpeed = 3.0f;

	[SerializeField]
	private float FireForce = 500.0f;

	[SerializeField]
	private float ReloadSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		this.PlayerCannon = new Cannon (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		float horizontalRotateAxis = Input.GetAxis ("Mouse X");
		float verticalRotateAxis = Input.GetAxis ("Mouse Y");

		if (horizontalRotateAxis != 0) {
			this.PlayerCannon.RotateHorizontal (horizontalRotateAxis * RotateSpeed);
		}

		if (verticalRotateAxis != 0) {
			this.PlayerCannon.RotateVertical (verticalRotateAxis * RotateSpeed);
		}

		if (Input.GetMouseButtonDown(0)) {
				
			if (this.PlayerCannon.IsLoaded) {
				this.PlayerCannon.Fire (FireForce);
				StartCoroutine (this.PlayerCannon.Reload(ReloadSpeed));
			}
		}
	}
}
