using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        protected virtual void OnInput(ModelBase modelBase, InputType inputType, float inputStrength) { }

        protected T GetView<T>() where T : ViewBase
        {
            return ViewToModel.Keys.FirstOrDefault(x => x is T) as T;
        }

        protected ModelBase GetModelOfView<T>() where T : ViewBase
        {
            var view = GetView<T>();

            return view != null ? ViewToModel[view] : null; 
        }

        protected void DestroyViews<T>() where T : ViewBase
        {
            var viewsToDestroy = ViewToModel.Keys.Where(x => x.GetType() == typeof(T)).ToList();
            foreach (var view in viewsToDestroy)
            {
                DestroyView(view);
            }
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
