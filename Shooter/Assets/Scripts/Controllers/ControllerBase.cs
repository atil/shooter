using UnityEngine;
using System.Collections;

namespace Shooter
{
    public abstract class ControllerBase : ObjectBase
    {
        public virtual void InitModel(ModelBase model) { }

        public virtual void OnModelCreated(ModelBase model) { }
        public virtual void OnViewCreated(ViewBase view) { }
    }

}
