using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public delegate void OnModelCreated(ModelBase model);
    public delegate void OnViewCreated(ViewBase view);
    public delegate void UpdateHandler();

    public static class Container
    {
        private static event UpdateHandler OnUpdate;

        private static readonly List<ModelBase> Models = new List<ModelBase>();
        private static readonly Dictionary<Type, Type> ElementToModel = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, Type> ElementToView = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, ControllerBase> ElementToController = new Dictionary<Type, ControllerBase>();
        private static readonly Dictionary<ModelBase, ViewBase> ModelToView = new Dictionary<ModelBase, ViewBase>();

        public static bool Init()
        {
            var elementTypes = (from lAssembly in AppDomain.CurrentDomain.GetAssemblies()
                     from lType in lAssembly.GetTypes()
                     where typeof(ElementBase).IsAssignableFrom(lType) && lType != typeof(ElementBase)
                     select lType).ToArray();

            foreach (var elemType in elementTypes)
            {
                var modelType = Type.GetType("Shooter." + elemType.Name + "Model");
                if (modelType == null)
                {
                    Debug.LogError("Model not found : " + elemType.Name);
                    return false;
                }
                ElementToModel.Add(elemType, modelType);

                var viewType = Type.GetType("Shooter." + elemType.Name + "View");
                if (viewType == null)
                {
                    Debug.LogError("View not found : " + elemType.Name);
                    return false;
                }
                ElementToView.Add(elemType, viewType);

                var controllerType = Type.GetType("Shooter." + elemType.Name + "Controller");
                if (controllerType == null)
                {
                    Debug.LogError("Controller not found : " + elemType.Name);
                    return false;
                }

                var controllerObj = (ControllerBase) Activator.CreateInstance(controllerType);
                ElementToController.Add(elemType, controllerObj);

                OnUpdate += controllerObj.Update;
            }

            return true;
        }

        public static void CreateElement<T>() where T : ElementBase
        {
            var modelObj = (ModelBase)Activator.CreateInstance(ElementToModel[typeof(T)]);
            var viewObj = (UnityEngine.Object.Instantiate(ViewBase.Resources[ElementToView[typeof(T)]]) as GameObject).GetComponent<ViewBase>();

            ModelToView.Add(modelObj, viewObj);
            Models.Add(modelObj);
            viewObj.BindTo(modelObj);
            ElementToController[typeof(T)].InitModel(modelObj);

            foreach (var controller in ElementToController.Values)
            {
                controller.OnModelCreated(modelObj);
                controller.OnViewCreated(viewObj);
            }
        }

        public static void DestroyModel(ModelBase model)
        {
            var view = ModelToView[model];
            view.OnModelDestroyed();
            Models.Remove(model);
            ModelToView.Remove(model);

            model = null;
        }

        public static void Update()
        {
            if (OnUpdate != null)
            {
                OnUpdate();
            }
        }
    }

}
