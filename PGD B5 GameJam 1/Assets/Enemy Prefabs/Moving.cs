using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {


	public float enemySpeed;
	public int toTarget;
	public Transform target;


	// Use this for initialization
	void Start()
	{
		enemySpeed = Random.value + 0.1f;
		target = GameObject.Find("Player").transform;
	}


	// Update is called once per frame
	void Update () {

		
	}
	void FixedUpdate()
	{
		Vector2 toTarget = target.transform.position - transform.position;
		

		transform.Translate(toTarget * enemySpeed * Time.deltaTime);

		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			Destroy(gameObject);
			Destroy(collision.gameObject);
		}

	}
}
