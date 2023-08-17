using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Private variables
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] private float horsePower = 0;
    [SerializeField] const float turnSpeed = 25.0f;
    [SerializeField] static float horizontalInput;
    [SerializeField] static float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            // Move the vehicle forward 
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);

            // Rotate the vehicle based on horizontal input
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed:" + speed + "mph");

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM:" + rpm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
           return true;
        }
        else
        {
           return false;
        }
    }
}
