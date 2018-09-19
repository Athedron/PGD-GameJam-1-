using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameObject hotDogPrefab;
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

		var hotDog = (GameObject)Instantiate(hotDogPrefab, transform.position, transform.rotation);

		Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
		hotDog.GetComponent<Rigidbody2D>().velocity = direction.normalized * 10;
		Destroy(hotDog, 5f);
		hotDog.transform.SetParent(transform);
	}
}

