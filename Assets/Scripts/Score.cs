using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private float scoreTime;
    public int tempScore;
    public int score;

    public Text scoreText;

    private void Awake() {
        StartCoroutine("ScoreCount");
        scoreText.text = "0";
    }

    private void Update() {
        scoreTime = 10f / ObstacleMovement.obstacleSpeed; 
    }

    IEnumerator ScoreCount() {
        while (true) {
            yield return new WaitForSeconds(scoreTime);
            ++tempScore;
            scoreText.text = tempScore.ToString();
        }

    }
}
