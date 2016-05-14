using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shooter
{
	public class BotShipController : ShipController
	{
	    [Inject]
        private WorldObjects _worldObjects;
        private List<BotShipModel> _botShips = new List<BotShipModel>();

	    public override void InitModelView(ModelBase m, ViewBase v)
	    {
	        base.InitModelView(m, v);
	        var botModel = (BotShipModel)m;
	        botModel.Speed = 0.01f;

	        var coll = _worldObjects.BotSpawnArea;
	        var randomPoint = coll.bounds.center + coll.bounds.extents * Random.Range(-1f, 1f); // TODO: Not random enough

	        botModel.Position = randomPoint;
	        botModel.Rotation = Quaternion.AngleAxis(180f, Vector3.forward);

	        //SetInputDispathcer(botModel, new BotInputDispatcher(Random.Range(1f, 5f)));
	    }

	}
}