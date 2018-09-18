using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public float  Maxhealth = 200 , health = 200;
    public GameObject camera;

    // Use this for initialization
    void Start()
    {
		health = Maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = transform.position - new Vector3(-1080/2/108, 0, 10);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 10f;
			Debug.Log("1");
		}
        if (collision.gameObject.tag == "EnemyCore")
        {
            health -= 20f;
			Debug.Log("2");
        }
    }
}