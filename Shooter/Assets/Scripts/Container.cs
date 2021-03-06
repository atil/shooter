﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Shooter
{
    public static class Container
    {
        private static readonly Dictionary<Type, Type> ElementToModel = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, Type> ElementToView = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, ControllerBase> ElementToController = new Dictionary<Type, ControllerBase>();

        private static readonly Dictionary<Type, object> DependencyContainer = new Dictionary<Type, object>();

        public static bool Init(object[] dependencies)
        {
            foreach (var dependency in dependencies)
            {
                DependencyContainer.Add(dependency.GetType(), dependency);
            }

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

                // Controllers can be dependencies
                DependencyContainer.Add(controllerType, controllerObj);
            }

            // Inject dependencies to controllers
            foreach (var controller in ElementToController.Values)
            {
                foreach (var field in controller.GetType()
                   .GetPrivateFields()
                   .Where(f => f.IsDefined(typeof(InjectAttribute), true)))
                {
                    if (DependencyContainer.ContainsKey(field.FieldType))
                    {
                        field.SetValue(controller, DependencyContainer[field.FieldType]);
                    }
                }

                controller.Init();
            }

            return true;
        }

        private static IEnumerable<FieldInfo> GetPrivateFields(this Type t) // TODO: Move to Utils.cs or something
        {
            if (t == null)
            {
                return Enumerable.Empty<FieldInfo>();
            }

            const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
            return t.GetFields(flags).Concat(GetPrivateFields(t.BaseType));
        }

        public static void CreateElement<T>() where T : ElementBase
        {
            var modelObj = (ModelBase)Activator.CreateInstance(ElementToModel[typeof(T)]);
            var resourceObj = ShooterResources.GetResource(ElementToView[typeof (T)]);
            var viewObj = ((GameObject)UnityEngine.Object.Instantiate(resourceObj)).GetComponent<ViewBase>();

            viewObj.name += UnityEngine.Random.Range(1, 999);

            ElementToController[typeof(T)].InitModelView(modelObj, viewObj);

        }

    }

}
