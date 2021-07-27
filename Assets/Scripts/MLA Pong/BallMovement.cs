using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [Header("Observations")]
    public float speed = 1;
    public Vector3 direction;

    //Private things
    private Transform t;
    private Vector3 originPoint;

    private void Awake() {
        this.t = GetComponent<Transform>();
        this.originPoint = this.gameObject.transform.localPosition;
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
            Vector3 newDir = this.gameObject.transform.localPosition - go.transform.localPosition;
            this.direction = newDir.normalized;
            this.speed *= 1.01f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        this.transform.localPosition = this.originPoint;

        if(other.gameObject.TryGetComponent<GoalLogic>(out GoalLogic goalLogic)) {
            goalLogic.triggered();
        }
    }
}
