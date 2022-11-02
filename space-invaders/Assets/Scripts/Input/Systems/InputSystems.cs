using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common
{
    public class InputSystems : Feature
    {
        private readonly Contexts _contexts;

        private bool _isHolding;
        private Vector3 _holdingPosition;
        private bool _isStartedHolding;
        private bool _isReleased;
        private float _holdingTime;

        private readonly Camera _camera;
        private readonly Dictionary<KeyCode, InputEntity> _keyEntities = new Dictionary<KeyCode, InputEntity>();

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

            MouseAndTouchProcessing();
            KeyProcessing();

            base.Execute();
        }

        private void ProcessKey(KeyCode code)
        {
            if (Input.GetKeyUp(code))
            {
                if (_keyEntities.TryGetValue(code, out var entity))
                {
                    entity.AddKeyReleased(code);
                    entity.RemoveKeyHoldingTime();
                    entity.RemoveKeyStartedHolding();
                    entity.isDestroyed = true;
                }

                _keyEntities.Remove(code);
                return;
            }

            if (Input.GetKeyDown(code))
            {
                var inputEntity = _contexts.input.CreateEntity();
                inputEntity.ReplaceKeyHoldingTime(0);
                inputEntity.ReplaceKeyStartedHolding(code);
                _keyEntities.Add(code, inputEntity);
            }
            else
            {
                if (_keyEntities.TryGetValue(code, out var entity))
                {
                    if (Input.GetKey(code))
                    {
                        entity.ReplaceKeyHoldingTime(entity.keyHoldingTime.Value + _contexts.input.deltaTime.Value);
                    }
                    else
                    {
                        entity.isDestroyed = true;
                        _keyEntities.Remove(code);
                    }
                }
            }
        }


        private void KeyProcessing()
        {
            ProcessKey(KeyCode.LeftArrow);
            ProcessKey(KeyCode.RightArrow);
            ProcessKey(KeyCode.Space);
        }


        private void MouseAndTouchProcessing()
        {
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
        }
    }
}