using System;
using System.Threading;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using YooAsset;

namespace ET
{
#if UNITY_EDITOR
	// 注册Editor下的Log
	[InitializeOnLoad]
	public class EditorRegisteLog
	{
		static EditorRegisteLog()
		{
			Game.ILog = new UnityLogger();
		}
	}
#endif
	
	public partial class Init: MonoBehaviour
	{
		public GlobalConfig GlobalConfig;
		
		private void Awake()
		{

			var x = 1 << 10;
			AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
			{
				Log.Error(e.ExceptionObject.ToString());
			};
			SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);
			DontDestroyOnLoad(gameObject);

			Game.ILog = new UnityLogger();
			
			LoadAssetsAndHotfix().Coroutine();
		}

		public async ETTask LoadAssetsAndHotfix()
		{
			await YooAssetInitHelper.Start();

			var Mode = YooAssetInitHelper.GetMode();
			if(Mode == YooAssets.EPlayMode.HostPlayMode)
				await HotfixProcedureHelper.OnEnter();
			
			await LoadAotCode();
			
			CodeLoader.Instance.GlobalConfig = this.GlobalConfig;
			
			try
			{
				await CodeLoader.Instance.Start();
			}
			catch (Exception e)
			{
				Log.Error($"{e}"); 
			}

		}
		
		private void Update()
		{
			CodeLoader.Instance.Update?.Invoke();
		}

		private void LateUpdate()
		{
			CodeLoader.Instance.LateUpdate?.Invoke();
		}

		private void OnApplicationQuit()
		{
			CodeLoader.Instance.OnApplicationQuit();
			CodeLoader.Instance.Dispose();
		}
	}
}