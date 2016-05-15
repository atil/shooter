using UnityEngine;
using System.Collections;

namespace Shooter
{
    public class PlayerInputDispatcher : InputDispatcherBase
    {
        private Vector3 _prevMousePos;

        private void Awake()
        {
            _prevMousePos = Input.mousePosition;
        }

        protected override void Update()
        {
            base.Update();
            
            #region Keyboard
            if (Input.GetKey(KeyCode.A))
            {
                DispatchInput(InputType.Left);
            }

            if (Input.GetKey(KeyCode.S))
            {
                DispatchInput(InputType.Down);
            }

            if (Input.GetKey(KeyCode.D))
            {
                DispatchInput(InputType.Right);
            }

            if (Input.GetKey(KeyCode.W))
            {
                DispatchInput(InputType.Up);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                DispatchInput(InputType.Fire);
            }
            #endregion

            #region Mouse
            var delta = Input.mousePosition - _prevMousePos;
            const float mouseStr = 4f;

            DispatchInput(InputType.Right, Input.GetAxis("Mouse X") * mouseStr);
            DispatchInput(InputType.Up, Input.GetAxis("Mouse Y") * mouseStr);

            _prevMousePos = Input.mousePosition;
            #endregion
        }

    }
}