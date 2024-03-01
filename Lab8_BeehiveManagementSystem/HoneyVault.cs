﻿using System.Runtime.CompilerServices;

namespace Lab8_BeehiveManagementSystem
{
	static class HoneyVault
	{
		private static float honey = 25f;
		private static float nectar = 100f;
		public const float NECTAR_CONVERSION_RATIO = .19f;
		public const float LOW_LEVEL_WARNING = 10f;

		static void ConvertNectarToHoney(float amount)
		{
			if (amount > nectar)
			{
				honey += nectar * NECTAR_CONVERSION_RATIO;
				nectar = 0f;
			}
			honey += amount * NECTAR_CONVERSION_RATIO;
			nectar -= amount;
		}

		static bool ConsumeHoney(float amount)
		{
			if (honey >= amount)
			{
				honey -= amount;
				return true;
			}
			return false;
		}

		static void CollectNectar (float amount)
		{
			if (amount > 0f)
			{
				nectar += amount;
			}
		}

		public static string StatusReport
		{
			get
			{
				string status = $"{honey:0.0} units of honey\n" + 
								$"{nectar:0.0} units of nectar";
				string warnings = "";
				if (honey < LOW_LEVEL_WARNING)
				{
					warnings += "\nLOW HONEY - ADD A HONEY MANUFACTURER";
				}
				if (nectar < LOW_LEVEL_WARNING)
				{
					warnings +=	"\nLOW NECTAR - ADD A NECTAR COLLECTOR";
				}
				return status + warnings;
			}
		}
	}
}
