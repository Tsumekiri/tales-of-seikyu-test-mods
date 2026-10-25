using ACEGame;
using HarmonyLib;
using UnityEngine;

namespace QuickFishing;

[HarmonyPatch(typeof(FishingCatchExecute), nameof(FishingCatchExecute.OnExecute))]
public class FishingCatchExecutePatch
{
    internal static void Prefix()
    {
        var fish = FishingDataUtil.GetCatchingFish();
        var player = GameEntity.Player?.CurrentMask;

        if (fish is null || player is null)
            return;

        var pos = new Vector3(0, 0, 0.25f);
        pos = player.transform.TransformPoint(pos);

        fish.transform.position = pos;
    }
}
