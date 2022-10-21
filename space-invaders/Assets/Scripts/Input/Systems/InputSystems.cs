using UnityEngine;
using UnityEngine.InputSystem;

namespace Common
{
    public class InputSystems : Feature
    {
        private readonly Contexts _contexts;

        private bool _isHolding = false;
        private Vector3 _holdingPosition = new Vector3(-1, -1, -1);
        private bool _isStartedHolding = false;
        private bool _isReleased = false;
        private float _holdingTime = 0f;
        private readonly Camera _camera;

        public InputSystems(Contexts contexts, Camera camera)
        {
            _contexts = contexts;

            _camera = camera;
        }

        public override void Execute()
        {
            if (_contexts.game.isPause)
            {
                return;
            }

            if (Pointer.current.press.isPressed)
            {
                if (_isHolding)
                {
                    _holdingTime += _contexts.input.deltaTime.Value; // float delta
                    _isStartedHolding = false;
                }
                else
                {
                    _holdingTime = 0f;
                    _isStartedHolding = true;
                }

                _holdingPosition = Pointer.current.position.ReadValue();
                _isHolding = true;
                _isReleased = false;
            }
            else
            {
                if (_isHolding)
                {
                    _isHolding = false;
                    _isReleased = true;
                }
                else
                {
                    _isReleased = false;
                }
            }


            _contexts.input.ReplaceDeltaTime(Time.deltaTime);
            _contexts.input.ReplaceRealtimeSinceStartup(Time.realtimeSinceStartup);

            if (_contexts.gameState.isGameOver)
            {
                _contexts.input.isPointerHolding = false;
                _contexts.input.isPointerStartedHolding = false;
                _contexts.input.isPointerReleased = true;
            }
            else
            {
                _contexts.input.isPointerHolding = _isHolding;
                _contexts.input.isPointerStartedHolding = _isStartedHolding;
                _contexts.input.isPointerReleased = _isReleased;
                _contexts.input.ReplacePointerHoldingPosition(_holdingPosition);
                _contexts.input.ReplacePointerHoldingTime(_holdingTime);
            }

            base.Execute();
        }
    }
}