using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsBehavior : MonoBehaviour {

    private float gemSpawnTime = 7f;
    public GameObject gem;
    private float randomGemPosition;
    private float yGemPosition = 1.5f;
    private float zGemPosition = 60f;

    public static int gemsCount;

    private void Start() {
        StartCoroutine("SpawnGems");
    }


    IEnumerator SpawnGems() {
        while (true) {
            yield return new WaitForSeconds(gemSpawnTime);
            SpawnOneGem();

            gemSpawnTime = Random.Range(1, 11) / 2f;  
        }


    }

    private void SpawnOneGem() {
        randomGemPosition = Random.Range(-5, 6);

        Instantiate(gem, new Vector3(randomGemPosition, yGemPosition, zGemPosition), Quaternion.identity);
    }
}
