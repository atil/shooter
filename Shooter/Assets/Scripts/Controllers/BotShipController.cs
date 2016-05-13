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
	        botModel.Speed = 0.01f;

	        var coll = _worldObjects.BotSpawnArea;
	        var randomPoint = coll.bounds.center + coll.bounds.extents * Random.Range(-1f, 1f); // TODO: Not random enough

	        botModel.Position = randomPoint;
	        botModel.Rotation = Quaternion.AngleAxis(180f, Vector3.forward);

	        SetInputDispathcer(botModel, new BotInputDispatcher());
	    }

	    public override void Update()
	    {
	        base.Update();
            // Destroy bots when they are out of screen
	    }
	}
}