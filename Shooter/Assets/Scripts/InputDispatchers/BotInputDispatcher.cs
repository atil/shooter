using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Shooter
{
    public class BotInputDispatcher : InputDispatcherBase
    {
       public float WaveLength { get; set; }

        protected override void Update()
        {
            base.Update();

            DispatchInput(InputType.Left, Mathf.Sin(Time.time) * WaveLength);

            DispatchInput(InputType.Down);
        }
    }
}
