using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float shakeDistance = 0.1f; // Shaking along the y-axis
    public float shakeSpeed = 1; // How fast the shake motion will be 

    Vector3 initialPosition; // Initial Camera Position
    Vector3 shakeOffset; // Camera Position after the shake

    bool isShaking = false;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position; // Save the starting position
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            Vector3 pos = transform.position;
            Vector3 offsetPos = pos + shakeOffset;
            float currentDistance = offsetPos.y - initialPosition.y;
            if (shakeSpeed >= 0)
            {
                if (currentDistance > shakeDistance)
                {
                    shakeSpeed *= -1; // Reverse direction if moved too far up
                }
            }
            else
            {
                if (currentDistance < -shakeDistance)
                {
                    shakeSpeed *= -1; // Reverse direction if moved too far down
                }
            }
            shakeOffset.y += shakeSpeed * Time.deltaTime; // Apply shake movement     
            if (shakeOffset.y > shakeDistance) shakeOffset.y = shakeDistance;
            if (shakeOffset.y < -shakeDistance) shakeOffset.y = -shakeDistance;
            transform.position = initialPosition + shakeOffset;
        }
    }

    public void StartShaking()
    {
        isShaking = true;
    }

    public void StopShaking()
    {
        isShaking = false;
        transform.position = initialPosition; // Reset camera to starting position
    }
}
