using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Shooter
{
    public class BotInputDispatcher : InputDispatcherBase
    {
        public override void Update()
        {
            base.Update();

            DispatchInput(InputType.Left, Mathf.Sin(Time.time) * 5);

            DispatchInput(InputType.Down);
        }
    }
}
