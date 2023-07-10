﻿using System;

namespace ET
{
	[Flags]
	public enum SceneType: ulong
	{
		None = 0,
		Process = 1,
		Manager = 1 << 2,
		Realm = 1 << 3,
		Gate = 1 << 4,
		Http = 1 << 5,
		Location = 1 << 6,
		Map = 1 << 7,
		Router = 1 << 8,
		RouterManager = 1 << 9,
		Robot = 1 << 10,
		BenchmarkClient = 1 << 11,
		BenchmarkServer = 1 << 12,
		Benchmark = 1 << 13,

		//Zeus
		Account = 1 << 20,
		Name = 1 << 21,
		Queue = 1 << 22,
		Monopoly = 1 << 23,
		ChatInfo = 1 << 24,

		// 客户端Model层
		Client = 1 << 30,
		Current = 1 << 30,
		
		Max = 1 << 100,
		All = ulong.MaxValue,
	}

	public static class SceneTypeHelper
	{
		public static bool HasSameFlag(this SceneType a, SceneType b)
		{
			if (((ulong) a & (ulong) b) == 0)
			{
				return false;
			}
			return true;
		}
	}
}