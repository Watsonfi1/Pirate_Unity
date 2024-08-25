using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    [Header("Movement")]
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start(){
        //getting my characters body?
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update(){
        //getting my input every frame
        MyInput();
    }

    private void FixedUpdate(){
        MovePlayer();
    }
    private void MyInput(){
        //defining how to get my input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer(){
        //movement direction
        moveDirection = orientation.foward * verticalInput + orientation.right * horizontalInput; 

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    }

}