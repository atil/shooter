using UnityEngine;
using System.Collections;

namespace Shooter
{
    public abstract class ControllerBase
    {
        protected event UpdateHandler OnUpdate;

        public virtual void InitModel(ModelBase m) { }

        public virtual void OnModelCreated(ModelBase model) { }
        public virtual void OnViewCreated(ViewBase view) { }

        public virtual void Update()
        {
            if (OnUpdate != null)
            {
                OnUpdate();
            }
        }
    }

}
