namespace FasterApparel
{
	using System.IO;
	using System.Reflection;
	using HarmonyLib;
	using RimWorld;
	using UnityEngine;
	using Verse;

	internal class FasterApparelMod : Mod
	{
		public static FasterApparelSettings settings;

		internal static string VersionDir => Path.Combine(ModLister.GetActiveModWithIdentifier("winggar.fasterapparel").RootDir.FullName, "Version.txt");
		public static string CurrentVersion { get; private set; }

		public FasterApparelMod(ModContentPack content) : base(content)
		{
			settings = GetSettings<FasterApparelSettings>();

			var version = Assembly.GetExecutingAssembly().GetName().Version;
			CurrentVersion = $"{version.Major}.{version.Minor}.{version.Build}";

			if (Prefs.DevMode)
			{
				File.WriteAllText(VersionDir, CurrentVersion);
			}

			new Harmony("winggar.fasterapparel").PatchAll();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			string DisplayFloatMultiplier(float x)
			{
				var timesTen = Mathf.RoundToInt(x * 10).ToString();
				return $"{timesTen.Substring(0, timesTen.Length - 1)}.{timesTen.Substring(timesTen.Length - 1, 1)}x";
			}

			var listingStandard = new Listing_Standard();
			listingStandard.Begin(inRect);

			var rect = listingStandard.GetRect(Text.LineHeight);
			var rect2 = listingStandard.GetRect(Text.LineHeight);

			Widgets.Label(rect, $"Apparel Speedup Factor: {DisplayFloatMultiplier(settings.fasterapparel_speedupFactor)}");
			settings.fasterapparel_speedupFactor = Widgets.HorizontalSlider
			(
				GenUI.BottomPart(rect2, 0.7f),
				settings.fasterapparel_speedupFactor,
				0.1f, 10f,
				middleAlignment: false,
				label: null,
				"Min: 0.1x", "Max: 10x",
				roundTo: 0.1f
			);

			listingStandard.End();

			base.DoSettingsWindowContents(inRect);
		}

		public override string SettingsCategory() => "FasterApparel".Translate();
	}
}