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

	        botModel.Position = RandomPointInVolume(_worldObjects.BotSpawnArea.bounds);
            botModel.Rotation = Quaternion.AngleAxis(180f, Vector3.forward);

            ((BodyView)view).OnVolumeEnter += OnVolumeEnter;
	    }

        private Vector3 RandomPointInVolume(Bounds bounds)
        {
	        return bounds.center + bounds.extents * UnityEngine.Random.Range(-1f, 1f); // TODO: Not random enough
        }

        private void OnVolumeEnter(ViewBase view1, ViewBase view2)
        {
            if (view2 == null) // Environment
            {
                // Environment kills respawns bot
                ((BotShipModel)ViewToModel[view1]).Position = RandomPointInVolume(_worldObjects.BotSpawnArea.bounds);
            }
            else
            {
                _bodyController.OnVolumeEnter(view1, view2);
            }
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