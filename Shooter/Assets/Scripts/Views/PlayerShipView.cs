using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class PlayerShipView : ShipView
	{
	    protected override void Awake()
        {
            base.Awake();
            InputDispatcher = gameObject.AddComponent<PlayerInputDispatcher>();
        }
	}
}