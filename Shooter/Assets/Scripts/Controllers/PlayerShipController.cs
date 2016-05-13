using System;
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
            playerModel.Speed = 0.05f;

            playerModel.InputDispatcher = new PlayerInputDispatcher();
            OnUpdate += playerModel.InputDispatcher.Update;

            playerModel.InputDispatcher.OnInput += (inputType) =>
            {
                OnInput(playerModel, inputType);
            };
        }

        private void OnInput(PlayerShipModel model, InputType t)
        {
            switch (t)
            {
                case InputType.Up:
                    model.Position += Vector2.up * model.Speed;
                    break;
                case InputType.Down:
                    model.Position += Vector2.down * model.Speed;
                    break;
                case InputType.Left:
                    model.Position += Vector2.left * model.Speed;
                    break;
                case InputType.Right:
                    model.Position += Vector2.right* model.Speed;
                    break;
                case InputType.Fire:
                    // TODO ...
                    break;
                default:
                    throw new ArgumentOutOfRangeException("t", t, null);
            }
        }
	}
}