using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RollerMovement : MonoBehaviour
{

    [Header("Car Settings")]
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;

    //Local Variables
    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

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

        ApplySteering();
         
    }

    void ApplyEngineForce()
    {
        //Create force for engine
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        //Apply force and push car forward
        guyRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        //update rotation angle based on input
        rotationAngle -= steeringInput * turnFactor;

        //Apply steering by rotating guy
        guyRigidbody2D.MoveRotation(rotationAngle);

    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
