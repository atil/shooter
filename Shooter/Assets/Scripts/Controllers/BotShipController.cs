using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Shooter
{
	public class BotShipController : ControllerBase
	{
        [Inject]
        private BodyController _bodyController;

	    [Inject]
        private WorldObjects _worldObjects;
        private List<BotShipModel> _botShips = new List<BotShipModel>();

	    public override void InitModelView(ModelBase model, ViewBase view)
	    {
	        base.InitModelView(model, view);
	        var botModel = (BotShipModel)model;
	        botModel.Speed = 0.01f;

	        var coll = _worldObjects.BotSpawnArea;
	        var randomPoint = coll.bounds.center + coll.bounds.extents * UnityEngine.Random.Range(-1f, 1f); // TODO: Not random enough

	        botModel.Position = randomPoint;
	        botModel.Rotation = Quaternion.AngleAxis(180f, Vector3.forward);

            ((BodyView)view).OnVolumeEnter += _bodyController.OnVolumeEnter;
	    }
        protected override void OnInput(ModelBase modelBase, InputType inputType, float inputStrength)
        {
            var model = (BotShipModel)modelBase;
            switch (inputType)
            {
                case InputType.Up:
                    model.Position += Vector2.up * model.Speed * inputStrength;
                    break;
                case InputType.Down:
                    model.Position += Vector2.down * model.Speed * inputStrength;
                    break;
                case InputType.Left:
                    model.Position += Vector2.left * model.Speed * inputStrength;
                    break;
                case InputType.Right:
                    model.Position += Vector2.right * model.Speed * inputStrength;
                    break;
                case InputType.Fire:
                    // TODO ...
                    break;
                default:
                    throw new ArgumentOutOfRangeException("t", inputType, null);
            }
        }

    }
}