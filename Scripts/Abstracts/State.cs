using UnityEngine;

namespace CharacterMovement
{
    public abstract class State
    {
        public abstract void Enter();
        public abstract void FixedUpdateState(float deltaTime);
        public abstract void UpdateState(float deltaTime);

        public abstract void Exit();
    }
}