using UnityEngine;
using System.Collections;

namespace Shooter
{
    public class PlayerInputDispatcher : InputDispatcherBase
    {
        const float MouseStrength = 4f;

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

            DispatchInput(InputType.Right, Input.GetAxis("Mouse X") * MouseStrength);
            DispatchInput(InputType.Up, Input.GetAxis("Mouse Y") * MouseStrength);

            if (Input.GetMouseButtonDown(0))
            {
                DispatchInput(InputType.Fire);
            }

            #endregion
        }

    }
}