﻿using System;
using CommandLine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ET.Client
{
	public class AfterShockInit : MonoBehaviour
	{
		private void Start()
		{
			this.StartAsync().Coroutine();
		}
		
		private async ETTask StartAsync()
		{
			DontDestroyOnLoad(gameObject);
			
			AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
			{
				Log.Error(e.ExceptionObject.ToString());
			};

			// 命令行参数
			string[] args = "".Split(" ");
			Parser.Default.ParseArguments<Options>(args)
				.WithNotParsed(error => throw new Exception($"命令行格式错误! {error}"))
				.WithParsed((o)=>World.Instance.AddSingleton(o));
			Options.Instance.StartConfig = $"StartConfig/Localhost";
			
			World.Instance.AddSingleton<Logger>().Log = new UnityLogger();
			ETTask.ExceptionHandler += Log.Error;
			
			World.Instance.AddSingleton<TimeInfo>();
			World.Instance.AddSingleton<FiberManager>();
			
			

			// FSMComponent fsmComponent = World.Instance.AddComponent<FSMComponent>();

			//World.Instance.AddSingleton<ResourcesComponent>();
			//await AssetsBundleHelper.InitializeAsync();
			//await AssetsBundleHelper.LoadCodeAsync();
			//await AssetsBundleHelper.LoadAotDllAsync();

			//World.Instance.AddSingleton<CodeLoader>().Start();
		}

		private void Update()
		{
			TimeInfo.Instance.Update();
			FiberManager.Instance.Update();
		}

		private void LateUpdate()
		{
			FiberManager.Instance.LateUpdate();
		}

		private void OnApplicationQuit()
		{
			World.Instance.Dispose();
		}
	}
}