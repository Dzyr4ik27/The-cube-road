using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour {

    public float rotationSpeed;

    private void FixedUpdate() {
        transform.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f));

    }
}
