using System.Linq;
using ACEGame;
using HarmonyLib;

namespace QuickHusbandry;

[HarmonyPatch(typeof(ActionSystemUtil))]
public class ActionSystemUtilPatch
{
    private static readonly string[] Actions = ["Touch", "CutHair", "Milk"]; // PutdownObject is for treats

    private static Entity GetPlayer() => GameEntity.Player?.CurrentMask?.Entity;

    private static bool IsPlayer(Entity entity) => entity == GetPlayer();

    private static bool ShouldProcess(ActionData data) => Actions.Contains(data?.ActiveAction?.ID);

    [HarmonyPostfix]
    [HarmonyPatch(nameof(ActionSystemUtil.ChangeAction))]
    internal static void ChangeAction(ActionData data, Entity entity)
    {
        if (!IsPlayer(entity))
            return;

        if (!ShouldProcess(data))
            return;

        data?.Speed = 10;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(ActionSystemUtil.ProcessEventWhenActionEnd))]
    internal static void ProcessEventWhenActionEnd(Entity entity)
    {
        if (!IsPlayer(entity))
            return;

        var action = entity?.ActionData();

        if (!ShouldProcess(action))
            return;

        action.RefreshSpeed();
    }
}
