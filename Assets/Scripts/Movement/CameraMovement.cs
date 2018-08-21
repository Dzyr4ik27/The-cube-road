using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform playerTransform;
    public Animator cameraAnimator;
    public float cameraSpeed = 0.125f;
    public Vector3 cameraOffset;
    private Vector3 defaultPosition;

    public static bool needToFollow ;

    

    private void Start() {
        cameraAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        SmoothFollow();
    }


    public void FollowPlayer() {
        defaultPosition = playerTransform.position + cameraOffset;
        //LerpFollow();
        transform.position = defaultPosition;
    }

    public void SmoothFollow() {
        defaultPosition = playerTransform.position + cameraOffset - Vector3.right * (playerTransform.position.x / 2.7f);
        LerpFollow();
    }

    public void LerpFollow() {
        transform.position = Vector3.Lerp(transform.position, defaultPosition, cameraSpeed);
    }

   





}
