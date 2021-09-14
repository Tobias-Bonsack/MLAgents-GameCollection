using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class FieldManager : MonoBehaviour
    {
        [SerializeField] GameObject _manager;
        private bool _isSet = false;
        private GameObject _icon = null;
        private bool? _playerID = null;


        public bool SetIcon(GameObject icon, bool playerID)
        {
            if (_isSet) return false;

            _icon = Instantiate(icon, transform.parent.transform);

            _isSet = true;
            _playerID = playerID;
            return _isSet;
        }

        public bool? GetStatus() => _playerID;
    }
}
