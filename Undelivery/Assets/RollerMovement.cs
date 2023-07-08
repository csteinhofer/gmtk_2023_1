using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RollerMovement : MonoBehaviour
{

    [Header("Car Settings")]
    public float driftFactor = 0.05f;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float dragFactor = 2.0f;
    public float maxSpeed = 10;

    //Local Variables
    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    float velocityVsUp;
    //Components
    Rigidbody2D guyRigidbody2D;

    void Awake()
    {
          guyRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        ApplyEngineForce();

        killOrthogonalVelocity();

        ApplySteering();
         
    }

    void ApplyEngineForce()
    {
        //Calculate how "forward" we are in terms of velocity direction
        velocityVsUp = Vector2.Dot(transform.up, guyRigidbody2D.velocity);

        //Limit for max speed
        if (velocityVsUp > maxSpeed && accelerationInput > 0)
            return;

        //Limit so we cannot go faster than 50% max speed in "reverse"
        if (velocityVsUp > -maxSpeed * 0.5f && accelerationInput < 0)
            return;

        //limit so we cannot go faster in any direction while accelerating
        if (guyRigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
            return;

        //Apply drag if no accelerationInput so car stops when player lets go of accelerator
        if (accelerationInput == 0)
            guyRigidbody2D.drag = Mathf.Lerp(guyRigidbody2D.drag, dragFactor, Time.fixedDeltaTime * 3);
        else guyRigidbody2D.drag = 0;


        //Create force for engine
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        //Apply force and push car forward
        guyRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {

        float minSpeedBeforeAllowingTurningFactor = (guyRigidbody2D.velocity.magnitude / 8);
        minSpeedBeforeAllowingTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowingTurningFactor);


        //update rotation angle based on input
        rotationAngle -= steeringInput * turnFactor;

        //Apply steering by rotating guy
        guyRigidbody2D.MoveRotation(rotationAngle);

    }

    void killOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(guyRigidbody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(guyRigidbody2D.velocity, transform.right);

        guyRigidbody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
