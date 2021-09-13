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
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool SetIcon(GameObject icon)
        {
            if (_isSet) return false;

            _icon = Instantiate(icon, gameObject.transform);

            _isSet = true;
            return _isSet;
        }
    }
}
