using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {


	public float enemySpeed;
	public int toTarget;
	public Transform target;
	public bool isHit;

    private GameObject enemyBase;
    private Vector2 basePos;
	// Use this for initialization
	void Start()
	{
		enemySpeed = Random.value + 6f;
		target = GameObject.Find("Player").transform;

        enemyBase = GameObject.Find("Base");
        basePos = enemyBase.transform.position;
	}


	// Update is called once per frame
	void Update () {


        
    }
	void FixedUpdate()
	{
		Vector2 toTarget = (target.transform.position - transform.position).normalized;
		transform.Translate(toTarget * enemySpeed * Time.deltaTime);

        if(isHit) if ((Vector2)transform.position == basePos) Destroy(this.gameObject);
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet" && !isHit)
		{
            print("enemy collision met bullet");
			isHit = true;
			target = GameObject.Find("Base").transform;
			enemySpeed = 10f;
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
