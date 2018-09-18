using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour {

	public GameObject hotDogPrefab;
	public Transform hotDogSpawn;
	public int bulletCount = 0;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonUp(0)) {

			if (transform.childCount <= 10){
			Shoot();
			bulletCount++;
		}

		}
		
	}

	public void Shoot() {

		var hotDog = (GameObject)Instantiate(hotDogPrefab, hotDogSpawn.position, hotDogSpawn.rotation);

		Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - hotDogSpawn.position).normalized;
		hotDog.GetComponent<Rigidbody2D>().velocity = direction.normalized * 10;
		Destroy(hotDog, 5f);

		hotDog.transform.SetParent(transform);
		

	}
	
}

