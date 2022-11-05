namespace FasterApparel
{
	using HarmonyLib;
	using RimWorld;

	[HarmonyPatch(typeof(JobDriver_Wear), nameof(JobDriver_Wear.Notify_Starting))]
	internal class FasterApparelPatch_JobDriver_Wear
	{
		[HarmonyPostfix]
		static void PostFix(ref int ___duration) => ___duration = (int)(___duration / FasterApparelMod.settings.fasterapparel_speedupFactor);
	}
}