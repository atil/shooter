using System;
using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class PlayerShipController : ControllerBase
	{
        [Inject]
        private BodyController _bodyController;

        public override void InitModelView(ModelBase model, ViewBase view)
        {
            base.InitModelView(model, view);
            ((PlayerShipModel)model).Speed = 0.05f;

            ((BodyView)view).OnVolumeEnter += _bodyController.OnVolumeEnter;

        }
        protected override void OnInput(ModelBase modelBase, InputType inputType, float inputStrength)
        {
            var model = (PlayerShipModel)modelBase;
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
                    Container.CreateElement<Bullet>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("t", inputType, null);
            }
        }

    }
}