using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZ : MonoBehaviour {

    
    public float rotationSpeed = 100f;

    private void FixedUpdate() {
        //rb.MoveRotation(rb.rotation * rotation);
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime));
        
    }
}
