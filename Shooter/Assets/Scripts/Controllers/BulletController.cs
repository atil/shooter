using UnityEngine;
using System.Collections;
using System;

namespace Shooter
{
	public class BulletController : BodyController
	{
        [Inject]
        private BodyController _bodyController;

        public override void InitModelView(ModelBase model, ViewBase view)
        {
            base.InitModelView(model, view);
            ((BulletModel)model).Speed = 0.5f;
            ((BulletModel)model).Position = (GetModelOfView<PlayerShipView>() as PlayerShipModel).Position + Vector2.up;
            ((BulletView)view).OnVolumeEnter += _bodyController.OnVolumeEnter;
        }

        protected override void OnInput(ModelBase modelBase, InputType inputType, float inputStrength)
        {
            var model = (BulletModel)modelBase;
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
                default:
                    throw new ArgumentOutOfRangeException("t", inputType, null);
            }
        }

    }
}