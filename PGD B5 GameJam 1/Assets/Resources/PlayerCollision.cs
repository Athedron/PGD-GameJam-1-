using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public float damage = 0, health = 500;
    public GameObject camera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = transform.position - new Vector3(-1080/2/108, 0, 10);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            damage += 1f;
			Debug.Log("1");
		}
        if (collision.gameObject.tag == "EnemyCore")
        {
            damage += 2f;
			Debug.Log("2");
        }
    }
}