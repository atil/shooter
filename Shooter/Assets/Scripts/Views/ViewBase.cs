using UnityEngine;
using System.Collections;

namespace Shooter
{
    public abstract class ViewBase : ObjectBase
    {
        public virtual void BindTo(ModelBase model) { }

        public virtual void OnModelDestroyed() { }
    }

}
