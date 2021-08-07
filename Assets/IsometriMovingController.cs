using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometriMovingController : MonoBehaviour
{
    public float movementSpeed = 1f;
    Rigidbody2D rb;
    Vector2 movement;
    IsometricSpineRenderer renderer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponentInChildren<IsometricSpineRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        movement = inputVector * movementSpeed;
        renderer.setSpeed(movement.magnitude);
        renderer.setDirection(movement);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            renderer.attack();
        }
    }

    private void FixedUpdate()
    {
        Vector2 currentPosition = rb.position;
        rb.MovePosition(currentPosition + movement * Time.deltaTime);
        renderer.setDirection(movement);
    }

}
