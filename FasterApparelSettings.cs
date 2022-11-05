namespace FasterApparel
{
	using Verse;

	internal class FasterApparelSettings : ModSettings
	{
		private const float DEFAULT_SPEEDUP_FACTOR = 3f;

		public float fasterapparel_speedupFactor = DEFAULT_SPEEDUP_FACTOR;

		public override void ExposeData()
		{
			base.ExposeData();

			Scribe_Values.Look(ref fasterapparel_speedupFactor, "fasterapparel_speedupFactor", DEFAULT_SPEEDUP_FACTOR);
		}
	}
}