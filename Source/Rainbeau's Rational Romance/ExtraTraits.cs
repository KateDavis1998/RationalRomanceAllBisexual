using RimWorld;
using Verse;

namespace RationalRomance_Code;

public static class ExtraTraits
{
    // Returns true if pawn already has an orientation trait.
    public static bool HasOrientation(Pawn pawn)
    {
        return pawn.story?.traits != null && (
            pawn.story.traits.HasTrait(TraitDefOf.Asexual) ||
            pawn.story.traits.HasTrait(TraitDefOf.Bisexual) ||
            pawn.story.traits.HasTrait(TraitDefOf.Gay) ||
            pawn.story.traits.HasTrait(RRRTraitDefOf.Straight)
        );
    }

    public static void AssignOrientation(Pawn pawn)
    {
        // Do not assign orientation for undefined-gender pawns.
        if (pawn?.gender == Gender.None || pawn.story?.traits == null)
            return;

        // Force every pawn to be bisexual to avoid assignment of other orientations.
        pawn.story.traits.GainTrait(new Trait(TraitDefOf.Bisexual));

        // Optionally assign polyamorous according to settings.
        if (Rand.Value < RationalRomance.Settings.PolyChance / 100f)
            pawn.story.traits.GainTrait(new Trait(RRRTraitDefOf.Polyamorous));
    }
}