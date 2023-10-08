using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ET.Client
{
	public partial class CodeLoader: Singleton<CodeLoader>
	{
		private Assembly model;

		public void Start()
		{
			// GlobalConfig globalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
			//
			// if (Define.EnableDll && YooAssetInitHelper.IsEditor())
			// {
			// 	if (globalConfig.CodeMode != CodeMode.ClientServer)
			// 	{
			// 		throw new Exception("ENABLE_CODES mode must use ClientServer code mode!");
			// 	}
			//
			// 	Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			// 	Dictionary<string, Type> types = AssemblyHelper.GetAssemblyTypes(assemblies);
			// 	EventSystem.Instance.Add(types);
			// 	foreach (Assembly ass in assemblies)
			// 	{
			// 		string name = ass.GetName().Name;
			// 		if (name == "Unity.Model.Codes")
			// 		{
			// 			this.model = ass;
			// 		}
			// 	}
			// 	IStaticMethod start = new StaticMethod(model, "ET.Entry", "Start");
			// 	start.Run();
			// }
			// else
			// {
			// 	LoadCodeByYooooo().Coroutine();
			// }
		}

		// 热重载调用下面两个方法
		// CodeLoader.Instance.LoadLogic();
		// EventSystem.Instance.Load();
		public void LoadHotfix()
		{
			this.LoadHotfixByYooooo().Coroutine();
		}
	}
}