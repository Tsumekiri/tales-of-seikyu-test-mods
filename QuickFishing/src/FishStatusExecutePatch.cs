using ACEGame;
using HarmonyLib;

namespace QuickFishing;

[HarmonyPatch(typeof(FishStatusExecute), nameof(FishStatusExecute.OnExecute))]
public class FishStatusExecutePatch
{
    internal static void Prefix()
    {
        var fish = FishingDataUtil.GetCatchingFish()?.Entity;
        var data = fish?.FishStatusData();

        data?.Strength = 0;
        data?.Recovery = true;
        fish?.SetProperty(ActionPropertyName.StrengthEmptyTrue, true);
    }
}
