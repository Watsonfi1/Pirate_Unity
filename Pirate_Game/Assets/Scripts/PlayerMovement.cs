using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour {

    public class Enemy : Entity { }

    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float groundDrag;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    public float jumpForce;

    public bool isOnGround = true;

    Rigidbody rb;

    public MovementState state;

    public enum MovementState {
        walking,
        sprinting,
        crouching,
        air
    }

private void Start() {
    //getting my characters body?
    rb = GetComponent<Rigidbody>();
    rb.freezeRotation = true;

    startYScale = transform.localScale.y;
    }

private void Update() {
        //getting my input every frame
        //checks if ground is below
        grounded = isOnGround;

    MyInput();
    SpeedControl();
    StateHandler();
    //drag
    if (grounded)
        rb.drag = groundDrag;
    else
        rb.drag = 0;

    if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        }
    }

private void FixedUpdate() {
    MovePlayer();
    }
private void MyInput() {
    //defining how to get my input
    horizontalInput = Input.GetAxisRaw("Horizontal");
    verticalInput = Input.GetAxisRaw("Vertical");

    if(Input.GetKeyDown(crouchKey)) {
        transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

    if(Input.GetKeyUp(crouchKey)) {
        transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }
private void MovePlayer() {
    //movement direction
    moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
    //on the ground
    rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

private void StateHandler() {
    if (grounded && Input.GetKey(crouchKey)) {
        state = MovementState.crouching;
        moveSpeed = crouchSpeed;
        }

    if (grounded && Input.GetKey(sprintKey)) {
        state = MovementState.sprinting;
        moveSpeed = sprintSpeed;
        }
    else if (grounded) {
        state = MovementState.walking;
        moveSpeed = walkSpeed;
        }
    else {
        state = MovementState.air;
        }
    }


private void SpeedControl() {
    Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

    //limit velocity
    if (flatVel.magnitude > moveSpeed) {
        Vector3 limitedVel = flatVel.normalized * moveSpeed;
        rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }


    }

private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("Ground")) {
        isOnGround = true;
        }
    }

}
