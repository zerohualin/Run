using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cfg;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ET
{
    public static class FGUIHelper
    {
        public static void BindRoot(Type type, object bindObj, GComponent gComponent)
        {
            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                var attribute = fieldInfo.GetCustomAttributes(typeof (BaseAttribute), false).FirstOrDefault();
                if (attribute != null)
                {
                    if (attribute is FGUIObjectAttribute)
                    {
                        if (fieldInfo.FieldType == typeof (Controller))
                        {
                            Controller ctrl = gComponent.GetController(fieldInfo.Name);
                            fieldInfo.SetValue(bindObj, ctrl);
                        }
                        else if (fieldInfo.FieldType == typeof (Transition))
                        {
                            Transition tran = gComponent.GetTransition(fieldInfo.Name);
                            fieldInfo.SetValue(bindObj, tran);
                        }
                        else
                        {
                            GObject gObj = gComponent.GetChild(fieldInfo.Name);
                            if (gObj != null)
                            {
                                if (gObj.GetType() != fieldInfo.FieldType)
                                {
                                    Debug.LogError($"{type.Name}的{fieldInfo.Name}绑定失败,字段类型:{fieldInfo.FieldType.Name},组件类型{gObj.GetType().Name}。");
                                }
                                else
                                {
                                    fieldInfo.SetValue(bindObj, gObj);
                                }
                            }
                        }
                        continue;
                    }

                    if (attribute is FGUICustomComAttribute)
                    {
                        var gObj = gComponent.GetChild(fieldInfo.Name).asCom;
                        var ChildCom = (bindObj as Entity).AddComponent(fieldInfo.FieldType);
                        BindRoot(fieldInfo.FieldType, ChildCom, gObj);
                        fieldInfo.SetValue(bindObj, ChildCom);
                        continue;
                    }
                    
                    if (attribute is FGUISelfObjectAttribute)
                    {
                        fieldInfo.SetValue(bindObj, gComponent);
                    }
                }
            }
        }

        public static void BindRoot<T>(T bindObj, GComponent gComponent)
        {
            Type type = typeof (T);
            BindRoot(type, bindObj, gComponent);
        }

        public static void AddButtonListener(GButton button, Action action)
        {
            button.onClick.Add(() => action?.Invoke());
        }

        public static ETTask<GObject> CreateObjectAsync(string pkgName, string resName)
        {
            ETTask<GObject> tcs = ETTask<GObject>.Create(true);
            UIPackage.CreateObjectAsync(pkgName, resName, (go) =>
            {
                tcs.SetResult(go);
                tcs = null;
            });
            return tcs.GetAwaiter();
        }
    }
}