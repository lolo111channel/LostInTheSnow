using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LostInTheSnow
{


    public class SimpleStateMachineController : MonoBehaviour
    {
        [SerializeField] private string _startState = "test";
        [SerializeField] private List<MonoBehaviour> _components = new();
        [SerializeField] private List<StateMachineState> _states = new();
        [SerializeField] private StateMachineState _currentState = new();

        public void ChangeStateTo(string stateName)
        {
            foreach (var component in _components)
            {
                component.enabled = false;
            }

            StateMachineState state = _states.Select(x=>x).Where(x=>x.StateName == stateName).FirstOrDefault();
            if (state != null)
            {
                foreach (var component in state.Components)
                {
                    component.enabled = true;
                }

                _currentState = state;
            }
        }


        private void Start()
        {
            ChangeStateTo(_startState);
        }


        [Serializable]
        private class StateMachineState
        {
            public string StateName = "test";
            public List<MonoBehaviour> Components = new();
        }
    }

}


