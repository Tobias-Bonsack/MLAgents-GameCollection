using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong;
using System;

namespace Pong
{
    public class PongLife : AbstractResetEpisode
    {
        [SerializeField] GameObject manager;
        [SerializeField] LifeManager lifeManager;
        [SerializeField] string gameOverText;
        public int life = 3;

        private void Awake()
        {
            this.AddToEvent(manager);
        }

        public void isHitted()
        {
            lifeManager.CurrentLife(--life);

            if (life <= 0)
            {
                this.manager.GetComponent<EventManager>().TriggerOnGameOver(this, new EventManager.OnGameOverEventArgs { winner = gameOverText });

            }
        }

        protected override void ResetGameObject()
        {
            this.life = 3;
        }
    }
}
