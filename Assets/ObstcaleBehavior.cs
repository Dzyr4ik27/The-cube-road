using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstcaleBehavior : MonoBehaviour {

    public float scaleIncreaseSpeed;
    public float scaleDecreaseSpeed;


    private void FixedUpdate() {
        IncreaseScale();
        DecreaseScale();
    }

    void IncreaseScale() {
        transform.GetChild(0).localScale += Vector3.one * scaleIncreaseSpeed * Time.fixedDeltaTime;
    }

    void DecreaseScale() {
        transform.GetChild(0).localScale += Vector3.one * scaleIncreaseSpeed * Time.fixedDeltaTime;
    }
}
