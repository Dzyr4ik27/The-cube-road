using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClicksBehavior : MonoBehaviour {

	public void OnGameOverClick() {
        ObstacleMovement.obstacleSpeed = 27f;
        SceneManager.LoadScene(0);
    }

    
}
