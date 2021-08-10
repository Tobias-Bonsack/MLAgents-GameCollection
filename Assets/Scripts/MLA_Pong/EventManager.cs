using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public class EventManager : MonoBehaviour
    {

        public event StartNewEpisodeDelegate startNewEpisodeEvent;
        public event AgentLifeDelegate agentLifeEvent;

        public void TriggerSNEE()
        {
            startNewEpisodeEvent();
        }
        public void TriggerALE(int damage)
        {
            agentLifeEvent(damage);
        }
    }
}
