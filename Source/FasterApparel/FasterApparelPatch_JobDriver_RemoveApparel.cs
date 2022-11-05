namespace FasterApparel
{
	using HarmonyLib;
	using RimWorld;

	[HarmonyPatch(typeof(JobDriver_RemoveApparel), nameof(JobDriver_RemoveApparel.Notify_Starting))]
	internal class FasterApparelPatch_JobDriver_RemoveApparel
	{
		[HarmonyPostfix]
		static void PostFix(ref int ___duration) => ___duration = (int)(___duration / FasterApparelMod.settings.fasterapparel_speedupFactor);
	}
}