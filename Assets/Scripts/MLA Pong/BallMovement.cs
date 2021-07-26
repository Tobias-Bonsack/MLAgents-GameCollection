using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [Header("Observations")]
    public int speed;
    public Vector3 direction;

    //Private things
    private Transform t;

    private void Awake() {
        this.t = GetComponent<Transform>();
    }

    private void FixedUpdate() {
        Vector3 move = direction * speed * Time.deltaTime;
        this.t.localPosition += move;
    }

    private void OnCollisionEnter(Collision other) {
        GameObject go = other.gameObject;
        if(go.CompareTag("Wall")) { //If it hits a wall, mirror z-axis
            direction = new Vector3(direction.x, direction.y, -direction.z).normalized;
        } else if(go.CompareTag("Agent")) { // if it hits a agent(player), calculate new direction
            //TODO change behavior to new one
            direction = new Vector3(-direction.x, direction.y, direction.z).normalized;
        }
    }

    //TODO: should reset the game, cost one life of enemy or give one point to scorrer
    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject); // if player scores one point
    }
}
