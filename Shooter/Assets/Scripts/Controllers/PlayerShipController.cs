using System;
using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class PlayerShipController : ShipController
	{
        public override void InitModel(ModelBase m)
        {
            base.InitModel(m);
            var playerModel = (PlayerShipModel)m;
            playerModel.Speed = 0.05f;
            SetInputDispathcer(playerModel, new PlayerInputDispatcher());
        }
        
	}
}