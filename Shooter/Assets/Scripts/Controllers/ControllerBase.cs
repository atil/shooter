using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shooter
{
    public abstract class ControllerBase
    {
        protected static Dictionary<ViewBase, ModelBase> ViewToModel = new Dictionary<ViewBase, ModelBase>();

        public virtual void Init() { }

        public virtual void InitModelView(ModelBase model, ViewBase view)
        {
            model.PropertyChanged += view.ModelPropertyChanged;
            ViewToModel.Add(view, model);

            view.OnInputDispatch += (inputType, strength) =>
            {
                OnInput(ViewToModel[view], inputType, strength);
            };

        }

        protected virtual void OnInput(ModelBase modelBase, InputType inputType, float inputStrength)
        {

        }
        protected void DestroyView(ViewBase view)
        {
            view.OnDestroyed();
            var model = ViewToModel[view];
            model = null;
            ViewToModel.Remove(view);
        }


    }

}
