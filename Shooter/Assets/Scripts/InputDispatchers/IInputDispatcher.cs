using UnityEngine;
using System.Collections;

namespace Shooter
{
    public enum InputType
    {
        Up, Down, Left, Right,
        Fire
    }

    public delegate void InputEvent(InputType t);

	public interface IInputDispatcher
	{
        event InputEvent OnInput;
	}
}