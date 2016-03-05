﻿using UnityEngine;
using System.Collections;
using com.teamred.carnivalgame;
using System;

public class PlayerCannonBehaviour : MonoBehaviour {

	private Cannon PlayerCannon;

	[SerializeField]
	private float RotateSpeed = 3.0f;

	[SerializeField]
	private float FireForce = 10.0f;

	[SerializeField]
	private float ReloadSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		this.PlayerCannon = new Cannon (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		float rotateAxis = Input.GetAxisRaw ("Horizontal");

		if (rotateAxis != 0) {
			this.PlayerCannon.Rotate (rotateAxis * RotateSpeed);
		}

		if (Input.GetKeyDown (KeyCode.Space) ||
			Input.GetKeyDown (KeyCode.Return) ||
			Input.GetKeyDown (KeyCode.KeypadEnter)) {
				
			if (this.PlayerCannon.IsLoaded) {
				this.PlayerCannon.Fire (FireForce);
				StartCoroutine (this.PlayerCannon.Reload(ReloadSpeed));
			}
		}
	}
}