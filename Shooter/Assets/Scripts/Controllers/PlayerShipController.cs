using System;
using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class PlayerShipController : ShipController
	{
        public override void InitModelView(ModelBase m, ViewBase v)
        {
            base.InitModelView(m, v);
            var playerModel = (PlayerShipModel)m;
            playerModel.Speed = 0.05f;
            //SetInputDispathcer(playerModel, new PlayerInputDispatcher());
        }
        
	}
}