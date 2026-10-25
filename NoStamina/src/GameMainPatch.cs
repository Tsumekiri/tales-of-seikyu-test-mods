using ACEConfig;
using ACEGame;
using HarmonyLib;

namespace NoStamina;

using EnterPlaying = GameMain._EnterPlayingState_d__28;

[HarmonyPatch(typeof(EnterPlaying), nameof(EnterPlaying.MoveNext))]
public class GameMainPatch
{
    internal static void Postfix(EnterPlaying __instance)
    {
        if (__instance.__1__state != -1)
            return;

        game_action.Global.fert_cost = 0;
        game_action.Global.fishing_cost = 0;
        game_action.Global.hit_cost = 0;
        game_action.Global.sow_cost = 0;
        game_action.Global.watering_cost = 0;
    }
}
