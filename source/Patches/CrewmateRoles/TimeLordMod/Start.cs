using System;
using HarmonyLib;
using TownOfUs.Roles;

namespace TownOfUs.CrewmateRoles.TimeLordMod
{
    // Upewnij się, że poprawnie odnajdujesz typ wewnętrzny
    
    public static class Start
    {
        // Zaktualizuj sygnaturę metody zgodnie z faktycznym typem
        public static void Postfix(IntroCutscene __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.TimeLord))
            {
                var TimeLord = (TimeLord)role;
                TimeLord.FinishRewind = DateTime.UtcNow;
                TimeLord.StartRewind = DateTime.UtcNow;
                TimeLord.FinishRewind = TimeLord.FinishRewind.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.RewindCooldown);
                TimeLord.StartRewind = TimeLord.StartRewind.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.RewindCooldown);
                TimeLord.StartRewind = TimeLord.StartRewind.AddSeconds(-10.0f);
            }
        }
    }
}
