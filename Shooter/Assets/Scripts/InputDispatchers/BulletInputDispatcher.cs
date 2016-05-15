using UnityEngine;
using System.Collections;

namespace Shooter
{
    public class BulletInputDispatcher : InputDispatcherBase
    {
        protected override void Update()
        {
            base.Update();
            DispatchInput(InputType.Up);
        }

    }
}