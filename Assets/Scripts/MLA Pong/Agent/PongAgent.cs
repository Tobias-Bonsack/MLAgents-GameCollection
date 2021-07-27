using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.InputSystem;
public class PongAgent : Agent
{

    [Header("Observations")]
    [SerializeField] GameObject ball;
    [SerializeField] GameObject enemy;

    [Header("Others")]
    [SerializeField] GameObject manager;

    public override void OnEpisodeBegin()
    {
        manager.GetComponent<EventManager>().TriggerSNEE();
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

    public void AddExternalReward(float reward) {
        AddReward(reward);
    }

    public void EndExternalEpisode() {
        EndEpisode();
    }

}
