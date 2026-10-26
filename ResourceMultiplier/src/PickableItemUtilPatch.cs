using ACEGame;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;

namespace ResourceMultiplier;

[HarmonyPatch(typeof(PickableItemUtil), nameof(PickableItemUtil.GetPackageItems))]
public class PickableItemUtilPatch
{
    internal static void Postfix(ref List<ItemPair> __result)
    {
        foreach (var pair in __result)
        {
            pair?.Count *= 4;
        }
    }
}
