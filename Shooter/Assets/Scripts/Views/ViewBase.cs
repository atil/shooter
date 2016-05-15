using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace Shooter
{
    public delegate void OnInputDispatchHandler(InputType inputType, float strength);

    public abstract class ViewBase : MonoBehaviour
    {
        public static Dictionary<Type, Object> Resources;

        static ViewBase()
        {
            Resources = new Dictionary<Type, Object>()
            {
                // TODO: These paths should be read from an xml / json
                {typeof(SessionView), UnityEngine.Resources.Load<Object>("Prefabs/SessionView")},
                {typeof(PlayerShipView), UnityEngine.Resources.Load<Object>("Prefabs/PlayerShipView")},
                {typeof(BotShipView), UnityEngine.Resources.Load<Object>("Prefabs/BotShipView")},
                {typeof(BulletView), UnityEngine.Resources.Load<Object>("Prefabs/BulletView")},
            };
        }

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
