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
            if (life != 0)
            {
                StartCoroutine(KillHeart(hearts[life].GetComponent<MeshRenderer>()));
            }
        }

        private IEnumerator KillHeart(MeshRenderer heart)
        {

            heart.material = heartMaterials[2];
            yield return new WaitForSeconds(1f);
            heart.material = heartMaterials[0];
        }

    }
}
