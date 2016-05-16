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

        private float _seed;

        private void Awake()
        {
            _seed = UnityEngine.Random.Range(-10f, 10f);
        }

        protected override void Update()
        {
            base.Update();

            DispatchInput(InputType.Left, (Mathf.Sin(Time.time) * _seed) * WaveLength); // Could be much better

            DispatchInput(InputType.Down);
        }
    }
}
