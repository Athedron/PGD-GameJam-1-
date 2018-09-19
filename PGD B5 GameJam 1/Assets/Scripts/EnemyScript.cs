using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {


	public float enemySpeed;
	public Transform target;
	public bool isHit, alreadyHitPlayer;

    private GameObject enemyBase, gameMaster;
    private Vector2 basePos;

    private Vector3 zPosFix;
	void Start()
	{
        zPosFix = transform.position;
        zPosFix.z = 0;
        transform.position = zPosFix;

        gameMaster = GameObject.Find("GameMaster");

		enemySpeed = Random.value + 6f;
		target = GameObject.Find("Player").transform;

        enemyBase = GameObject.Find("Base");
        basePos = enemyBase.transform.position;
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
			isHit = true;
			target = GameObject.Find("Base").transform;
            EnemyIsHit();
            Destroy(collision.gameObject);
            gameMaster.GetComponent<GameMasterScript>().stress--;
            gameMaster.GetComponent<GameMasterScript>().score ++;
            gameMaster.GetComponent<GameMasterScript>().UpdateScore();
            CancelInvoke();
        }

        if(collision.gameObject.name == "Player" && !alreadyHitPlayer)
        {
            alreadyHitPlayer = true;
            gameMaster.GetComponent<GameMasterScript>().stress++;
            InvokeRepeating("InflictStress", 0f, 1f);
        }

        if(collision.gameObject.name == "Base")
        {
            Destroy(this.gameObject);
        }
    }

    void InflictStress()
    {
        gameMaster.GetComponent<GameMasterScript>().TakeStress();
    }

    void EnemyIsHit()
    {
        enemySpeed = 5f;
        GetComponent<SpriteRenderer>().color = Color.green;
        target = GameObject.Find("Base").transform;
    }
}
