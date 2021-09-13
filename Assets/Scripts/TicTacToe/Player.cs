using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TicTacToe
{
    public class Player : MonoBehaviour
    {
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
                Debug.Log(context.ToString());
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                Debug.DrawLine(ray.origin, ray.GetPoint(10f), Color.red, 2f);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Debug.Log(hit.collider.gameObject.name);
                }
            }
        }

    }
}
