using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using static PulsarModLoader.Patches.HarmonyHelpers;

namespace Walk_with_order_menu_open
{
    [HarmonyPatch(typeof(PLPlayerController), "HandleMovement")]
    internal class PlayerController
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            // && !PLInput.Instance.GetButton(PLInputBase.EInputActionName.order_menu)
            List<CodeInstruction> targetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldsfld), //PLInput.Instance
                new CodeInstruction(OpCodes.Ldc_I4_S), //PLInputBase.EInputActionName.order_menu
                new CodeInstruction(OpCodes.Callvirt), //GetButton()
                new CodeInstruction(OpCodes.Brtrue) //&& !
            };

            //This list intentionally left blank
            List<CodeInstruction> patchSequence = new List<CodeInstruction>();

            return PatchBySequence(instructions, targetSequence, patchSequence, PatchMode.REPLACE, CheckMode.NEVER);
        }
    }
}
