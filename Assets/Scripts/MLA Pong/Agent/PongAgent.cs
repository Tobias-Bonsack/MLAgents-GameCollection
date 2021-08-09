using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.InputSystem;
using Pong;

namespace Pong
{
    public class PongAgent : Agent
    {

        [Header("Observations")]
        [SerializeField] GameObject ball;
        [SerializeField] int obsBallDirSign;

        [Header("Others")]
        [SerializeField] GameObject manager;

        [SerializeField] public bool isPlayer;

        public override void OnEpisodeBegin()
        {
            manager.GetComponent<EventManager>().TriggerSNEE();
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            //TODO normalize as many as possible

            // Observations from itself
            sensor.AddObservation(transform.localPosition.z);
            // absolute distance to ball
            sensor.AddObservation(Mathf.Abs(ball.transform.localPosition.x - transform.localPosition.x));
            // observations from the ball
            sensor.AddObservation(ball.gameObject.transform.localPosition.z);
            sensor.AddObservation(ball.gameObject.GetComponent<BallMovement>().direction.x * obsBallDirSign);
            sensor.AddObservation(ball.gameObject.GetComponent<BallMovement>().direction.z);
            sensor.AddObservation(ball.gameObject.GetComponent<BallMovement>().speed);
        }

        public override void Heuristic(in ActionBuffers actionsOut)
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard != null)
            {
                ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
                discreteActions[0] = keyboard.eKey.isPressed ? 0 : keyboard.dKey.isPressed ? 2 : 1;
            }
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            ActionSegment<int> discreteActions = actions.DiscreteActions;

            AgentMovement agentMovement = GetComponent<AgentMovement>();
            switch (discreteActions[0])
            {
                case 0: //Up
                    agentMovement.moveUp();
                    break;
                case 1: //Stay
                    break;
                default: //Down
                    agentMovement.moveDown();
                    break;
            }
        }

        public void AddExternalReward(float reward)
        {
            Debug.Log("Reward: " + reward);
            AddReward(reward);
        }

        public void EndExternalEpisode()
        {
            Debug.Log("End Episode");
            EndEpisode();
        }

    }
}
