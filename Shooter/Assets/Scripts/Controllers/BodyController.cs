using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shooter
{
	public class BodyController : ControllerBase
	{
        public override void InitModelView(ModelBase model, ViewBase view)
        {
            base.InitModelView(model, view);
            ((BodyModel)model).Position = view.transform.position;
            view.OnInputDispatch += (inputType, strength) =>
            {
                OnInput((BodyModel)ViewToModel[view], inputType, strength);
            };
            ((BodyView)view).OnVolumeEnter += OnVolumeEnter;
        }

        protected virtual void OnInput(BodyModel model, InputType inputType, float inputStrength)
	    {
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

        private void OnVolumeEnter(ViewBase collider, ViewBase collidee)
        {
            var model1 = ViewToModel[collider] as BodyModel;
            DestroyView(collider);

        }
    }

}