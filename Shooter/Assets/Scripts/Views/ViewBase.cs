using UnityEngine;

namespace Shooter
{
    public delegate void OnInputDispatchHandler(InputType inputType, float strength);

    public abstract class ViewBase : MonoBehaviour
    {
        public event OnInputDispatchHandler OnInputDispatch;

        private IInputDispatcher _inputDispatcher;
        protected IInputDispatcher InputDispatcher
        {
            get { return _inputDispatcher; }
            set
            {
                _inputDispatcher = value;
                _inputDispatcher.OnInput += (type, str) =>
                {
                    if (OnInputDispatch != null)
                    {
                        OnInputDispatch(type, str);
                    }
                };
            }
        }

        protected virtual void Awake() { }

        public virtual void ModelPropertyChanged(object sender, PropertyChangedEventArgs e) { }

        public virtual void OnDestroyed()
        {
            Destroy(gameObject);
        }
    }

}
