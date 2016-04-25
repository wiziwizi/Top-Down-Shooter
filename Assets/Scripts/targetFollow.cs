﻿using UnityEngine;
using System.Collections;

public class targetFollow : MonoBehaviour {

    public Transform target;

    private Vector3 offset;

	void Start () {
        offset = transform.position - target.position;
	}
	
	
	void LateUpdate () {
        transform.position = target.position + offset;
	}
}
