using System.Linq;
using ACEGame;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;

namespace QuickFishing;

[HarmonyPatch(typeof(FishingRotExecute), nameof(FishingRotExecute.OnExecute))]
public class FishingRotExecutePatch
{
    internal static void Prefix(List<Entity> entities)
    {
        var rotData = entities
            ._items.Select(i => i?.FishingRotData())
            .FirstOrDefault(i => i is not null);

        var baitData = rotData?.BaitUnit?.Entity?.BaitData();

        if (baitData?.PresetFish is null || rotData?.DummyTarget is null)
            return;

        baitData.PresetFish.position = rotData.DummyTarget.position;
    }
}
