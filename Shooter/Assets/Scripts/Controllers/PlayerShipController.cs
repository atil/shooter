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

            // Figure out how to dispatch inputs (where Update should be)
            //playerModel.InputDispatcher = //
        }
    }
}