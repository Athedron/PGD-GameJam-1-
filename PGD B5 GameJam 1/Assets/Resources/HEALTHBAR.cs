using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEALTHBAR : MonoBehaviour {


    GameObject obj, obj2;
    public GameObject player;
    PlayerCollision playerInfo;

    Sprite pixel;
    float barSize = 50; 

	// Use this for initialization
	void Start () {
        playerInfo = player.GetComponent<PlayerCollision>();

        pixel = Resources.Load("Sprites/fillpixel", typeof(Sprite)) as Sprite;

        obj = new GameObject("emptyBar");
        SpriteRenderer render = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        render.sprite = pixel;
        obj.transform.localScale = new Vector3(playerInfo.health, barSize, 1);

        obj2 = new GameObject("fillBar");
        SpriteRenderer render2 = obj2.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        render2.sprite = pixel;
        render2.color = new Color(255,0,0);

        obj.transform.position = new Vector3(0, -2, -2);
        obj2.transform.position = new Vector3(0, -2, -3);
    }
	
	// Update is called once per frame
	void Update () {
        if(playerInfo.health >= playerInfo.damage)
            obj2.transform.localScale = new Vector3(playerInfo.health - playerInfo.damage, barSize, 1);
    }
}
