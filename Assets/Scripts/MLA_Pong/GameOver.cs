using System.Globalization;
using System.Diagnostics.Tracing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Pong
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] EventManager eventManager;

        [Header("De-/Activate")]
        [SerializeField] GameObject toActivate;
        [SerializeField] GameObject[] toDeactivate;

        [Header("GameOver-Objects")]
        [SerializeField] TMP_Text text;
        [SerializeField] PongAgent resetAgent;

        private void Start()
        {
            this.eventManager.OnGameOver += ActionOnGameOver;
        }

        private void ActionOnGameOver(object sender, EventManager.OnGameOverEventArgs args)
        {
            Time.timeScale = 0f;
            ChangeVisibility(false, true);

            text.SetText(args.winner);
        }

        public void ResetGame()
        {
            Time.timeScale = 1f;
            ChangeVisibility(true, false);

            resetAgent.EndExternalEpisode();
        }

        private void ChangeVisibility(bool de, bool ac)
        {
            foreach (GameObject item in toDeactivate)
            {
                item.SetActive(de);
            }
            toActivate.SetActive(ac);
        }
    }
}
