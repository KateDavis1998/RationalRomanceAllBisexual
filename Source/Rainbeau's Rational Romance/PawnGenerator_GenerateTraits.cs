using HarmonyLib;
using RimWorld;
using Verse;

namespace RationalRomance_Code;

[HarmonyPatch(typeof(PawnGenerator), nameof(PawnGenerator.GenerateTraits), null)]
public static class PawnGenerator_GenerateTraits
{
    // CHANGE: Add orientation trait after other traits are selected.
    public static void Postfix(Pawn pawn)
    {
        if (ExtraTraits.HasOrientation(pawn))
            return;

        ExtraTraits.AssignOrientation(pawn);
    }
}