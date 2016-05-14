using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shooter
{
    public abstract class ControllerBase
    {
        protected static Dictionary<ViewBase, ModelBase> ViewToModel = new Dictionary<ViewBase, ModelBase>();

        public virtual void InitModelView(ModelBase model, ViewBase view)
        {
            model.PropertyChanged += view.ModelPropertyChanged;
            ViewToModel.Add(view, model);
        }

        protected void DestroyView(ViewBase view)
        {
            view.OnDestroyed();
            var model = ViewToModel[view];
            model = null;
            ViewToModel.Remove(view);
            UnityEngine.Object.Destroy(view.gameObject);
        }
    }

}
