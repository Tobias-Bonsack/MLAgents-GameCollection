using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong;

namespace Pong
{
    public class GoalLogic : MonoBehaviour
    {

        [SerializeField] GameObject protector;
        [SerializeField] GameObject attacker;

        public void triggered()
        {
            protector.GetComponent<PongAgent>().AddExternalReward(-1f);
            attacker.GetComponent<PongAgent>().AddExternalReward(0.5f);

            protector.GetComponent<PongLife>().isHitted(); // can end the episode
        }

    }
}
