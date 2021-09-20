using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] bool _turnID;
        [SerializeField] FieldManager[] _fieldManager;
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
            bool? winner = null; // draw
            for (int i = 0; i < 3; i++) //check rows and columns
            {
                for (int j = 0; j < 3; j++) //check columns
                {
                    if (_fieldManager[j].GetStatus() == _fieldManager[j + 3].GetStatus() // 
                     && _fieldManager[j].GetStatus() == _fieldManager[j + 6].GetStatus())
                    {
                        winner = _fieldManager[j].GetStatus();
                        if (winner != null) goto FoundWinner;
                    }
                }
                for (int j = 0; j < 7; j += 3) //check rows
                {
                    if (_fieldManager[j].GetStatus() == _fieldManager[j + 1].GetStatus() //
                     && _fieldManager[j].GetStatus() == _fieldManager[j + 2].GetStatus())
                    {
                        winner = _fieldManager[j].GetStatus();
                        if (winner != null) goto FoundWinner;
                    }
                }
            }

            if (_fieldManager[2].GetStatus() == _fieldManager[4].GetStatus() && _fieldManager[2].GetStatus() == _fieldManager[6].GetStatus() // check dia left-right
             || _fieldManager[0].GetStatus() == _fieldManager[4].GetStatus() && _fieldManager[0].GetStatus() == _fieldManager[8].GetStatus()) //check dia right-left
            {
                winner = _fieldManager[4].GetStatus();
                if (winner != null) goto FoundWinner;
            }

        FoundWinner:
            bool gameIsOver = true;
            foreach (FieldManager fM in _fieldManager)
            {
                if (fM.GetStatus() == null)
                {
                    gameIsOver = false;
                    break;
                }
            }
            if (gameIsOver || winner != null)
            {
                Debug.Log("GameOver: " + winner);
                //TODO gewinner event muss getriggert werden
            }
        }
        public bool GetTurnID() => _turnID;
    }
}

