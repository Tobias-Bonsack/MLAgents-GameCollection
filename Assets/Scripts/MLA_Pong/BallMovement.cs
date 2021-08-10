using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{


    public class BallMovement : AbstractResetEpisode
    {

        [Header("Observations")]
        public float speed;
        private float originSpeed;
        public Vector3 direction;

        [Header("Others")]
        [SerializeField] GameObject manager;

        //Private things
        private Transform t;
        private Vector3 originPoint;
        private void Awake()
        {
            this.t = GetComponent<Transform>();
            this.originPoint = this.gameObject.transform.localPosition;
            this.originSpeed = this.speed;
            this.AddToEvent(manager);
        }
        protected override void ResetGameObject()
        {
            transform.localPosition = originPoint;
            this.speed = this.originSpeed;
            this.direction = Random.Range(0, 2) == 1? Vector3.right : Vector3.left;
        }


        private void FixedUpdate()
        {
            Vector3 move = direction * speed * Time.deltaTime;
            this.t.localPosition += move;
        }

        private void OnCollisionEnter(Collision other)
        {
            GameObject go = other.gameObject;
            if (go.CompareTag("Wall"))
            { //If it hits a wall, mirror z-axis
                direction = new Vector3(direction.x, direction.y, -direction.z * 0.95f).normalized;
            }
            else if (go.CompareTag("Agent"))
            { // if it hits a agent(player), calculate new direction
              //Ball things
                Vector3 newDir = this.gameObject.transform.localPosition - go.transform.localPosition;
                this.direction = newDir.normalized;
                this.speed *= 1.01f;
                //Agent things
                if (other.gameObject.TryGetComponent<PongAgent>(out PongAgent pongAgent))
                {
                    pongAgent.AddExternalReward(0.5f);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            this.transform.localPosition = this.originPoint;

            if (other.gameObject.TryGetComponent<GoalLogic>(out GoalLogic goalLogic))
            {
                goalLogic.triggered();
                this.ResetGameObject();
            }

        }
    }
}
