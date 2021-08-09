using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MLA_Pong {
    public class PlayAgain : MonoBehaviour {
        [SerializeField] private TMP_Text resultText;
        [SerializeField] private Button playAgainButton;
        private float _timeScale;
        
        #region SingletonPattern

        public static PlayAgain Singleton { get; private set; }

        internal static event Action OnSingletonReady;

        private void Awake() {
            if (Singleton == null) {
                Singleton = this;
                OnSingletonReady?.Invoke();
            }
            else if (Singleton != this) {
                Debug.LogWarning("PlayAgain already exist.");
                Destroy(this);
            }
        }

        #endregion

        // Start is called before the first frame update
        void Start() {
            playAgainButton.onClick.AddListener(OnPlayAgainClicked);
        }

        // Update is called once per frame
        void Update() {
        }

        public void SetLooser(bool isPlayer) {
            SetResultText(isPlayer ? "You lost!" : "You won!");
            setChildActive(true);
            // There is certainly a better solution, but this could be the simplest. 
            _timeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        private void setChildActive(bool active) {
            if (transform.childCount != 1) {
                Debug.LogError("Cannot Set PlayAgain View, check it's Child count.");
                return;
            }

            transform.GetChild(0).gameObject.SetActive(active);
        }

        private void SetResultText(string text) {
            resultText.text = text;
        }

        public void OnPlayAgainClicked() {
            setChildActive(false);
            Time.timeScale = _timeScale;
        }
    }
}