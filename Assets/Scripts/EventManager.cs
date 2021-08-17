using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class EventManager : MonoBehaviour
    {
        #region events
        public event EventHandler<OnChangeScenesEventArgs> OnChangeScenes;

        #endregion

        #region event args
        public class OnChangeScenesEventArgs
        {
            public int sceneNumber;
        }
        #endregion

        #region methods
        public void TriggerOnChangeScenes(object sender, OnChangeScenesEventArgs args) => this.OnChangeScenes?.Invoke(sender, args);
        public void TriggerOnChangeScenes(int scene) => this.OnChangeScenes?.Invoke(null, new OnChangeScenesEventArgs { sceneNumber = scene });


        #endregion


    }
}
