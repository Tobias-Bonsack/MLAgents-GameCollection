using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public class EventManager : MonoBehaviour
    {

        public event StartNewEpisodeDelegate startNewEpisodeEvent;
        public event AgentLifeDelegate agentLifeEvent;
        public event EventHandler<OnGameOverEventArgs> OnGameOver;
        public class OnGameOverEventArgs
        {
            public string winner;
        }

        public void TriggerSNEE() => startNewEpisodeEvent?.Invoke();
        public void TriggerALE(int damage) => agentLifeEvent?.Invoke(damage);
        public void TriggerOnGameOver(object sender, OnGameOverEventArgs e) => this.OnGameOver?.Invoke(sender, e);
        public void TriggerOnGameOver(string winner) => this.OnGameOver?.Invoke(null, new OnGameOverEventArgs { winner = winner });
    }
}
