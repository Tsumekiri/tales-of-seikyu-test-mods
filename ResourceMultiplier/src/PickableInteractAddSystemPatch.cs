using ACEGame;
using HarmonyLib;

namespace ResourceMultiplier;

[HarmonyPatch(typeof(PickableInteractAddSystem), nameof(PickableInteractAddSystem.OnPick))]
public class PickableInteractAddSystemPatch
{
    internal static void Prefix(Entity self)
    {
        var pickable = self?.PickableData();

        pickable?.ID?.Count *= 4;
        pickable?.ItemInfo?.Count *= 4;
    }
}
