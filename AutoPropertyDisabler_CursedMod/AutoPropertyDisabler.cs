using CursedMod.Events.Arguments.Player;
using CursedMod.Events.Handlers;
using CursedMod.Features.Wrappers.Player.Roles;
using CursedMod.Loader;
using CursedMod.Loader.Modules;

namespace AutoPropertyDisabler_CursedMod;

public class AutoPropertyDisabler : CursedModule
{
    public override string ModuleAuthor => "xNexusACS";
    public override string ModuleName => "AutoPropertyDisabler";
    public override string ModuleVersion => "1.0.0";
    public override string CursedModVersion => CursedModInformation.Version;

    public override void OnLoaded()
    {
        CursedPlayerEventsHandler.ChangingRole += OnChangingRole;
        base.OnLoaded();
    }

    public override void OnUnloaded()
    {
        CursedPlayerEventsHandler.ChangingRole -= OnChangingRole;
        base.OnUnloaded();
    }

    private void OnChangingRole(PlayerChangingRoleEventArgs ev)
    {
        ev.Player.HasNoClipPermitted = false;
        ev.Player.HasGodMode = false;

        if (ev.Player.CurrentRole is CursedFpcRole cursedFpcRole)
            cursedFpcRole.FpcModule.Motor.IsInvisible = false;
    }
}