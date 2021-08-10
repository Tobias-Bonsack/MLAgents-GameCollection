using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong;

namespace Pong
{
    public abstract class AbstractResetEpisode : MonoBehaviour
    {
        public virtual void AddToEvent(GameObject manager)
        {
            manager.GetComponent<EventManager>().startNewEpisodeEvent += ResetGameObject;
        }
        protected abstract void ResetGameObject();
    }
}
