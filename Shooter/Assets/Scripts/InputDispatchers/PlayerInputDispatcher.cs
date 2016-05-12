using UnityEngine;
using System.Collections;

namespace Shooter
{
    public class PlayerInputDispatcher : MonoBehaviour, IInputDispatcher
    {
        public event InputEvent OnInput;
    }
}