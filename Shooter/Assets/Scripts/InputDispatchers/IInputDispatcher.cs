using UnityEngine;
using System.Collections;

namespace Shooter
{
    public enum InputType
    {
        Up, Down, Left, Right,
        Fire,
        Replay,
        Pause
    }

    public delegate void InputEvent(InputType t, float strength);

	public interface IInputDispatcher
	{
        event InputEvent OnInput;
	}

    public class InputDispatcherBase : MonoBehaviour, IInputDispatcher
    {
        public event InputEvent OnInput;

        protected virtual void Update() { }

        protected void DispatchInput(InputType inputType, float strength = 1f)
        {
            if (Session.IsPaused // No inputs will be dispatched if paused
                && inputType != InputType.Pause) // Pauses always pass, though 
            {
                return;
            }

            if (OnInput != null)
            {
                OnInput(inputType, strength);
            }
        }
    }
}