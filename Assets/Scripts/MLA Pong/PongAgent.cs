using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
public class PongAgent : Agent
{

    [Header("Observations")]
    [SerializeField] GameObject ball;
    [SerializeField] GameObject enemy;

    public override void OnEpisodeBegin()
    {
        //TODO to something or not.
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //TODO normalize as many as possible

        // Observations from itself
        sensor.AddObservation(this.gameObject.transform.localPosition.x);
        sensor.AddObservation(this.gameObject.transform.localPosition.z);

        // observations from the ball
        sensor.AddObservation(ball.gameObject.transform.localPosition.x);
        sensor.AddObservation(ball.gameObject.transform.localPosition.z);
        sensor.AddObservation(ball.gameObject.GetComponent<BallMovement>().direction.x);
        sensor.AddObservation(ball.gameObject.GetComponent<BallMovement>().direction.z);
        sensor.AddObservation(ball.gameObject.GetComponent<BallMovement>().speed);

        // observations from the enemy
        sensor.AddObservation(enemy.gameObject.transform.localPosition.x);
        sensor.AddObservation(enemy.gameObject.transform.localPosition.z);

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //TODO implement player input system
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        ActionSegment<int> discreteActions = actions.DiscreteActions;
        switch (discreteActions[0])
        {
            case 0: //Up
                break;
            case 1: //Stay
                break;
            default: //Down
                break;
        }
    }


}
