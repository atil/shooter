using System;
using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class BodyController : ControllerBase
	{
	    protected void SetInputDispathcer(BodyModel bodyModel, InputDispatcherBase dispatcher)
	    {
	        bodyModel.InputDispatcher = dispatcher;
	        OnUpdate += bodyModel.InputDispatcher.Update;

	        bodyModel.InputDispatcher.OnInput += (inputType, strength) =>
	        {
	            OnInput(bodyModel, inputType, strength);
	        };

	    }

	    protected virtual void OnInput(BodyModel model, InputType inputType, float strength)
	    {
            switch (inputType)
            {
                case InputType.Up:
                    model.Position += Vector2.up * model.Speed * strength;
                    break;
                case InputType.Down:
                    model.Position += Vector2.down * model.Speed * strength;
                    break;
                case InputType.Left:
                    model.Position += Vector2.left * model.Speed * strength;
                    break;
                case InputType.Right:
                    model.Position += Vector2.right * model.Speed * strength;
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