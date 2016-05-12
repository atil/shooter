using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class PlayerShipView : ShipView
	{
        public override void BindTo(ModelBase model)
        {
            base.BindTo(model);

            var playerShipModel = (PlayerShipModel)model;
        }
    }
}