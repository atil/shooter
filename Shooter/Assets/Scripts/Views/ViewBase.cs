using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace Shooter
{
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


        public virtual void BindTo(ModelBase model)
        {
            model.PropertyChanged += ModelPropertyChanged;
        }

        protected virtual void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }

        public virtual void OnModelDestroyed() { }
    }

}
