using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBulletRain : MonoBehaviour {

    public GameObject robot;
    public GameObject bullet;
    
    private float yPosition = 15f;
    private float zPosition = 27f;

    private float bulletSpawnTime = 0f;

    private Vector3 endTrigger;


    private void Start() {
        SpawnRobot();
        Invoke("StartBulletRain", 1f);
        endTrigger = transform.GetChild(2).transform.position;
    }

    void StartBulletRain() {
        StartCoroutine("BulletRain");
    }

    void SpawnRobot() {
        Instantiate(robot, new Vector3(0f, yPosition, zPosition), Quaternion.identity);
        robot.GetComponent<OneObjectMovement>().enabled = false;
    }

    void SpawnBullet() {
        Instantiate(bullet, FindObjectOfType<RobotBehavior>().transform.GetChild(0).transform.position + Vector3.down * 1.5f, 
            Quaternion.identity);
    }

    IEnumerator BulletRain() {

        while (true) {
            yield return new WaitForSeconds(bulletSpawnTime);
            SpawnBullet();

            bulletSpawnTime = Random.Range(0.1f, 0.5f);
        }
    }



}
