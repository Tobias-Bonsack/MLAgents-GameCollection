using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TicTacToe
{
    public class Player : MonoBehaviour
    {
        [SerializeField] GameObject _icon;
        public void OpenMenu(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Debug.Log("Pressed Escape: " + context.ToString());
            }
        }

        public void Click(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (Physics.Raycast(ray, out RaycastHit hit) && //
                    hit.collider.gameObject.TryGetComponent<FieldManager>(out FieldManager fieldManager))
                {
                    fieldManager.SetIcon(_icon);
                }
            }
        }

    }
}
