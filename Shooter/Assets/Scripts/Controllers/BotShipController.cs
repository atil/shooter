using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class BotShipController : ShipController
	{
	    [Inject]
        private WorldObjects _worldObjects;

	    public override void InitModel(ModelBase m)
	    {
	        base.InitModel(m);
	        var botModel = (BotShipModel)m;
	        botModel.Speed = 0.05f;

	        var coll = _worldObjects.BotSpawnArea;
            // Place bot randomly in this collider
	    }
	}
}