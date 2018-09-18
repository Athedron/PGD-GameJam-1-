using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {


	public float enemySpeed;
	public int toTarget;
	public Transform target;
	public bool isHit;

	// Use this for initialization
	void Start()
	{
		enemySpeed = Random.value + 6f;
		target = GameObject.Find("Player").transform;
	}


	// Update is called once per frame
	void Update () {

		
	}
	void FixedUpdate()
	{
		Vector2 toTarget = (target.transform.position - transform.position).normalized;
		

		transform.Translate(toTarget * enemySpeed * Time.deltaTime);

		
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet" && !isHit)
		{
			//Destroy(gameObject);
			isHit = true;
			target = GameObject.Find("Base").transform;
			enemySpeed = 0.5f;
			GetComponent<SpriteRenderer>().color = Color.green;
			Destroy(collision.gameObject);
		}
		if (collision.gameObject.tag == "Cannon")
		{
			target = GameObject.Find("Base").transform;
			enemySpeed = 01f;
			GetComponent<SpriteRenderer>().color = Color.green;
		}
	}
}
