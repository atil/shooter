using UnityEngine;
using System.Collections;

namespace Shooter
{
    public class SessionInputDispatcher : InputDispatcherBase
    {
        public event OnReplayClicked OnReplayClicked;

        protected override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DispatchInput(InputType.Pause);
            }
        }

        public void OnReplayClickedCallback()
        {
            if (OnReplayClicked != null)
            {
                OnReplayClicked();
            }
        }
    }
}