using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] Global.EventManager globalEventManager;
        [SerializeField] Global.MainMenu globalMainMenu;
        [SerializeField] Animator animator;

        private void Start()
        {
            this.globalEventManager.OnChangeScenes += ActionOnChangeScenes;
        }

        private void ActionOnChangeScenes(object sender, Global.EventManager.OnChangeScenesEventArgs args)
        {
            StartCoroutine(localEnumerator());


            IEnumerator localEnumerator()
            {
                animator.SetTrigger("Start");
                yield return new WaitForSeconds(1f);
                this.globalMainMenu.LoadGame(args.sceneNumber);
            }
        }

    }
}
