using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Player player; // Reference to the player

    // This method runs once when the obstacle is created.
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // This method runs at fixed time intervals.
    private void FixedUpdate()
    {
        Vector2 pos = transform.position; // Current position of the obstacle

        pos.x -= player.velocity.x * Time.fixedDeltaTime; // Move the obstacle left based on the player's speed
        if (pos.x < -100) // If the obstacle is too far left
        {
            Destroy(gameObject); // Destroy it
        }

        transform.position = pos; // Update the position
    }
}
