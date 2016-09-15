using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Basket : MonoBehaviour {
    Vector3 mousePos2d;
    Vector3 mousePos3d;
    Vector3 pos;
    GameObject hit;
    public static int score;
    Text scoreText;
    Text highScoreText;



	void Start ()
    {
        score = 0;
        scoreText = GameObject.Find("ScoreCounter").GetComponent<Text>();
        highScoreText = GameObject.Find("HighScore").GetComponent<Text>();
        updateScore();


	}
	
	void Update ()
    {
        mousePos2d = Input.mousePosition;
        mousePos2d.z = 10; //Not going to dig through the main camera's transform's position, since it would vary if you moved the camera anyway.
        mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2d);
        pos = transform.position;
        pos.x = mousePos3d.x;
        transform.position = pos;
	}

    void OnCollisionEnter(Collision coll)
    {
        hit = coll.collider.gameObject;
        if (hit.CompareTag("Apple"))
        {
            Destroy(hit);
            score++;
            AppleTree.difficulty += 0.05f;
            updateScore();
        }
    }
    private void updateScore()
    {
        scoreText.text = score.ToString();
        if (score > HighScore.highScore)
        {
            highScoreText.gameObject.GetComponent<HighScore>().updateHighScore(score);
        }
    }
}
