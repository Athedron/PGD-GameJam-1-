using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour {

	public GameObject hotDogPrefab;
	public Transform hotDogSpawn;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			Shoot();
		}
	}

	public void Shoot() {

		var hotDog = (GameObject)Instantiate(hotDogPrefab, hotDogSpawn.position, hotDogSpawn.rotation);
		var direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - hotDogSpawn.position).normalized;
		
		hotDog.GetComponent<Rigidbody2D>().velocity = direction;
		Destroy(hotDog, 2.0f);
	}
	
}

