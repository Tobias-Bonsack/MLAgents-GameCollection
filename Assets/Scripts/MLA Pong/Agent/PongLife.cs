using System.Collections;
using System.Collections.Generic;
using MLA_Pong;
using UnityEngine;
using Pong;

namespace Pong
{
    public class PongLife : AbstractResetEpisode
    {
        [SerializeField] GameObject manager;
        [SerializeField] LifeManager lifeManager;
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
                GetComponent<PongAgent>().EndExternalEpisode();
                bool isPlayer = GetComponent<PongAgent>().isPlayer;
                PlayAgain.Singleton.SetLooser(isPlayer);
            }
        }

        protected override void ResetGameObject()
        {
            this.life = 3;
        }
    }
}
