using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterMovement
{
    public abstract class StateController : MonoBehaviour
    {
        private State _currentState;
        // Start is called before the first frame update
        public void SwitchState(State newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
        

        private void Update()
        {
            _currentState?.UpdateState(Time.deltaTime);
            customUpdate(Time.deltaTime);

        }

        private void FixedUpdate()
        {
            _currentState?.FixedUpdateState(Time.fixedDeltaTime);
            customFixedUpdate(Time.fixedDeltaTime);
        }

        public abstract void Move(Vector3 moveDirection, float deltaTime, float additionalSpeed=0);
        protected abstract void customUpdate(float deltaTime);
        protected abstract void customFixedUpdate(float deltaTime);


    }

}
