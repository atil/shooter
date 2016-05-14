using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class BotShipView : ShipView
	{
		protected override void Awake()
        {
            base.Awake();
            InputDispatcher = gameObject.AddComponent<BotInputDispatcher>();
            ((BotInputDispatcher)InputDispatcher).WaveLength = 2f;
        }
	}
}