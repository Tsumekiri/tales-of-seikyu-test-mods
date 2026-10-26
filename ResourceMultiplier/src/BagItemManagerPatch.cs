using System.Linq;
using ACEGame;
using HarmonyLib;

namespace ResourceMultiplier;

[HarmonyPatch(
    typeof(BagItemManager),
    nameof(BagItemManager.Add),
    [typeof(int), typeof(int), typeof(int), typeof(bool), typeof(bool)]
)]
public class BagItemManagerPatch
{
    private static readonly string[] Actions = ["fishingShow", "CutHair", "Milk"];

    private static bool ShouldMultiply(ActionData data) => Actions.Contains(data?.ActiveAction?.ID);

    internal static void Prefix(ref int count)
    {
        var player = GameEntity.Player?.CurrentMask?.Entity;
        var action = player?.ActionData();

        if (ShouldMultiply(action))
        {
            count *= 4;
        }
    }
}
