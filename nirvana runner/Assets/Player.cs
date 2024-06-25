using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public float jumpVelocity = 20;
    public float groundHeight = 10;
    public bool isGrounded = false;

    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;

    public float jumpGroundThreshhold = 3;

    void Start() {
        
    }

    void Update() {
        
        // Jump
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);
        if (isGrounded || groundDistance <= jumpGroundThreshhold) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                holdJumpTimer = 0.0f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            isHoldingJump = false;
        }
    }

    private void FixedUpdate() {
        Vector2 pos = transform.position;

        if (!isGrounded) {
            if (isHoldingJump) {
                holdJumpTimer += Time.fixedDeltaTime;
                if (holdJumpTimer >= maxHoldJumpTime) {
                    isHoldingJump = false;
                }
            }

            pos.y += velocity.y * Time.fixedDeltaTime; // Going up until v = 0
            if (!isHoldingJump) {
                velocity.y += gravity * Time.fixedDeltaTime; // Going down
            }

            // Hitting ground and stay
            if (pos.y <= groundHeight) {
                pos.y = groundHeight;
                isGrounded = true;
            }
        }

        transform.position = pos;
    }
}
