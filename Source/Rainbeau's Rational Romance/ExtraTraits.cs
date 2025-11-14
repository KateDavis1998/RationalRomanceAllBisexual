using RimWorld;
using Verse;

namespace RationalRomance_Code;

public static class ExtraTraits
{
    public static void AssignOrientation(Pawn pawn)
    {
        var orientation = Rand.Value;
        if (pawn.gender == Gender.None)
        {
            return;
        }
        // Force every pawn to be bisexual to avoid assignment of asexual/straight/gay.
        pawn.story.traits.GainTrait(new Trait(TraitDefOf.Bisexual));

        // Optionally assign polyamorous according to settings (preserve original behavior).
        if (Rand.Value < RationalRomance.Settings.PolyChance / 100)
        {
            pawn.story.traits.GainTrait(new Trait(RRRTraitDefOf.Polyamorous));
        }
    }
}