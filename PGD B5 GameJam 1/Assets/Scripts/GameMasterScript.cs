using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour {

    public int stress, score;

    public Text scoreText, gameOverText;
    public Image stressBarRed;
    private RectTransform rt;
    private Vector2 stressSize;

	void Start () {
        gameOverText.gameObject.SetActive(false);

        rt = stressBarRed.GetComponent < RectTransform > ();
        stressSize = rt.sizeDelta;
        rt.sizeDelta = new Vector2(0, stressSize.y); //reset stress bar to empty

    }
    void Update()
    {

    }
    public void TakeStress()
    {
        if (rt.sizeDelta.x < 200) rt.sizeDelta += new Vector2(stress, 0);
        else
        {
            rt.sizeDelta = new Vector2(200, stressSize.y);
            Time.timeScale = 0f;
            gameOverText.gameObject.SetActive(true);

        }
    }

    public void UpdateScore()
    {
        scoreText.text = "score: " + score;
    }
}
