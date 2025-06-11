using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float walkSpeed = 5f;
    Vector2 moveInput;
    public bool IsMoving { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {

        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * walkSpeed, rb.linearVelocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        Debug.Log(moveInput);
    }
}
