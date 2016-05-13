using UnityEngine;
using System.Collections;

namespace Shooter
{
    public class PlayerInputDispatcher : InputDispatcherBase
    {
        public override void Update()
        {
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

            if (Input.GetKey(KeyCode.Space))
            {
                DispatchInput(InputType.Fire);
            }

        }

    }
}