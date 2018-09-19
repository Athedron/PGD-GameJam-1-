using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour {

    public int health, damage, score;
	void Start () {
		
	}
    void Update()
    {
        if (damage < 0) damage = 0;
    }
    public void TakeDamage()
    {
        health -= damage;
    }
}
