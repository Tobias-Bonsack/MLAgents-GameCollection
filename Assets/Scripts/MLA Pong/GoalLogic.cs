using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong;

namespace Pong
{
    public class GoalLogic : MonoBehaviour
    {
        public void triggered()
        {
            protector.GetComponent<PongAgent>().AddExternalReward(-1f);
            protector.GetComponent<PongLife>().isHitted();
            attacker.GetComponent<PongAgent>().AddExternalReward(0.5f);
        }

        [SerializeField] GameObject protector;

        [SerializeField] GameObject attacker;
    }
}
