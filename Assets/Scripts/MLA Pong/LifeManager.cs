using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public class LifeManager : AbstractResetEpisode
    {

        [SerializeField] GameObject manager;
        [SerializeField] MeshRenderer[] hearts;
        [SerializeField] Material[] heartMaterials;

        protected override void ResetGameObject()
        {
            foreach (MeshRenderer mR in hearts)
            {
                mR.material = heartMaterials[1];
            };
        }

        private void Awake()
        {
            this.AddToEvent(manager);
        }

        public void CurrentLife(int life)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].material = life > i ? heartMaterials[1] : heartMaterials[0];
            }
        }

    }
}
