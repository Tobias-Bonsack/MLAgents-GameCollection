using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System.Linq;
using System;

namespace TicTacToe
{
    public class AgentBrain : Agent
    {
        [Header("Player")]
        [SerializeField] GameObject _manager;
        [SerializeField] GameObject _icon;
        [SerializeField] bool _turnID;

        [Header("Observations")]
        [SerializeField] FieldManager[] _fields;

        [Header("Ohters")]
        [SerializeField] float _decisionDelay = 0.5f;

        public override void Initialize()
        {
            //TODO add events
            _manager.GetComponent<EventManager>()._onEndTurn += ActionOnEndTurn;
        }

        private void ActionOnEndTurn(object sender, EventArgs e) => StartCoroutine(DecisionDelay());

        public override void OnEpisodeBegin()
        {
            if (IsTurn()) RequestDecision();
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            foreach (FieldManager fieldManager in _fields)
            {
                int value = -1; // does not happen
                switch (fieldManager.GetStatus())
                {
                    case null://is free
                        value = 0;
                        break;
                    case false://yours
                        value = 1;
                        break;
                    default://player
                        value = 2;
                        break;
                }
                sensor.AddObservation(value);
            }
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            ActionSegment<int> discreteActions = actions.DiscreteActions;
            if (!IsTurn()) return;

            if (_fields[discreteActions[0]].SetIcon(_icon, _turnID))
                _manager.GetComponent<EventManager>().TriggerOnEndTurn();
            else
            {
                Debug.Log("Choosen Field: " + discreteActions[0]);
                StartCoroutine(DecisionDelay());
            }
        }
        IEnumerator DecisionDelay()
        {
            Debug.Log(IsTurn());
            yield return new WaitForSeconds(_decisionDelay);
            Debug.Log(IsTurn());
            if (IsTurn()) RequestDecision();
        }
        private bool IsTurn() => _manager.GetComponent<GameManager>().GetTurnID() == this._turnID;

    }
}
