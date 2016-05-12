using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public delegate void OnModelCreated(ModelBase model);
    public delegate void OnViewCreated(ViewBase view);

    public static class Container
    {
        private static List<ModelBase> models = new List<ModelBase>();
        private static Dictionary<Type, Type> elementToModel = new Dictionary<Type, Type>();
        private static Dictionary<Type, Type> elementToView = new Dictionary<Type, Type>();
        private static Dictionary<Type, ControllerBase> elementToController = new Dictionary<Type, ControllerBase>();
        private static Dictionary<ModelBase, ViewBase> modelToView = new Dictionary<ModelBase, ViewBase>();

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
                elementToModel.Add(elemType, modelType);

                var viewType = Type.GetType("Shooter." + elemType.Name + "View");
                if (viewType == null)
                {
                    Debug.LogError("View not found : " + elemType.Name);
                    return false;
                }
                elementToView.Add(elemType, viewType);

                var controllerType = Type.GetType("Shooter." + elemType.Name + "Controller");
                if (controllerType == null)
                {
                    Debug.LogError("Controller not found : " + elemType.Name);
                    return false;
                }

                elementToController.Add(elemType, (ControllerBase)Activator.CreateInstance(controllerType));
            }

            return true;
        }

        public static void CreateElement<T>() where T : ElementBase
        {
            var modelObj = (ModelBase)Activator.CreateInstance(elementToModel[typeof(T)]);
            var viewObj = (UnityEngine.Object.Instantiate(ViewBase.Resources[elementToView[typeof(T)]]) as GameObject).GetComponent<ViewBase>();
            modelToView.Add(modelObj, viewObj);
            models.Add(modelObj);
            viewObj.BindTo(modelObj);
            elementToController[typeof(T)].InitModel(modelObj);

            foreach (var controller in elementToController.Values)
            {
                controller.OnModelCreated(modelObj);
                controller.OnViewCreated(viewObj);
            }
        }

        public static void DestroyModel(ModelBase model)
        {
            var view = modelToView[model];
            models.Remove(model);
            modelToView.Remove(model);

            model = null;
        }
    }

}
