﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

	public Transform Player;
	public Vector3 Offset;
	void Update () {
		transform.position = Player.position + Offset;
	}
}
