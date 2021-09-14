using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] bool _turnID;
        private void Awake()
        {
            GetComponent<EventManager>()._onEndTurn += CheckForWinner;
            GetComponent<EventManager>()._onEndTurn += ChangeTurnID;
        }

        private void ChangeTurnID(object sender, EventArgs e)
        {
            _turnID = !_turnID;
        }

        private void CheckForWinner(object caller, EventArgs args)
        {
            //TODO generate logic for checking winner
        }
        public bool GetTurnID() => _turnID;
    }
}
