using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TicTacToe
{
    public class Player : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] GameObject _manager;
        [SerializeField] GameObject _icon;
        [SerializeField] bool _turnID;
        public void OpenMenu(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Debug.Log("Pressed Escape: " + context.ToString());
            }
        }

        public void Click(InputAction.CallbackContext context)
        {
            if (IsTurn() && context.started)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (Physics.Raycast(ray, out RaycastHit hit) && //
                    hit.collider.gameObject.TryGetComponent<FieldManager>(out FieldManager fieldManager))
                {
                    if (fieldManager.SetIcon(_icon, _turnID))
                    {
                        _manager.GetComponent<EventManager>().TriggerOnEndTurn();
                    }
                }
            }
        }

        private bool IsTurn() => _manager.GetComponent<GameManager>().GetTurnID() == this._turnID;

    }
}
