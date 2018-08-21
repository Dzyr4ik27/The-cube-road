using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;
    public Animator animator;

    public float upForce = 100f;
    public float sidewaySpeed = 20f;
    Quaternion rotation;
    public float rotationSpeed = 100f;
    private float gravityScale = 100f;
    private float defaultGravityScale = 20f;

    private Vector3 newPosition;
    private float groundWidth = 12f;


    float distToGround;
    bool isGround;


    public float cameraSpeed;


   

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        distToGround = transform.localScale.y;
        animator = GetComponent<Animator>();
        //animator.SetTrigger("Start");
        //MoveAtStart();
    }


    private void FixedUpdate() {
        MovePlayer();
        isGround = IsGrounded(); 

    }

    void MoveAtStart() {
        transform.position = Vector3.Lerp(transform.position, Vector3.zero, cameraSpeed);
    }

    void MovePlayer() {
        Jump();
        Rotate();
        float tapPoint = Input.GetAxis("Horizontal") * sidewaySpeed * Time.deltaTime;
        newPosition = rb.position + Vector3.right * tapPoint;

        newPosition.x = Mathf.Clamp(newPosition.x, -(groundWidth / 2 - 0.6f), groundWidth / 2 - 0.6f);

        rb.MovePosition(newPosition);

        GetSmall();
    }

    void Jump() {
        if (Input.GetKey(KeyCode.UpArrow) && IsGrounded()) {
            rb.AddForce(Vector3.up * upForce * Time.fixedDeltaTime, ForceMode.Impulse); //timeDeltaTime
            //animator.SetTrigger("Jump");
        }

    }

    void GetSmall() {
        if (Input.GetKey(KeyCode.E)) {
            animator.SetTrigger("GetSmall");
        }
    }

    void Rotate() {
        rotationSpeed = ObstacleMovement.obstacleSpeed * 20f; // new code
        transform.Rotate(new Vector3(rotationSpeed * Time.deltaTime, 0f, 0f));
        
    }

    public bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.02f); //+0.05f
    }

}
