﻿using UnityEngine;
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
	    void Update();

	}

    public class InputDispatcherBase : IInputDispatcher
    {
        public event InputEvent OnInput;

        public virtual void Update() { }

        protected void DispatchInput(InputType inputType)
        {
            if (OnInput != null)
            {
                OnInput(inputType);
            }
        }
    }
}