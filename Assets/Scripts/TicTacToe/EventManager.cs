using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class EventManager: MonoBehaviour
    {
        #region events
        public EventHandler<EventArgs> _onEndTurn;
        #endregion

        #region event args
        #endregion

        #region triggers
        public void TriggerOnEndTurn() => _onEndTurn?.Invoke(null, null);
        #endregion

    }
}
