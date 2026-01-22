using Celeste.Mod.CelesteModTutorial.Utils;

namespace Celeste.Mod.CelesteModTutorial;

public sealed class CelesteModTutorialModule : EverestModule
{
    public static CelesteModTutorialModule Instance { get; private set; }

    public override void Load()
    {
        Instance = this;
        Logger.Log(LogLevel.Info, "CelesteModTutorial", "Hello, Celeste!");

        AttributeHelper.InvokeAllMethods<LoadAttribute>();
    }

    public override void Unload()
    {
        AttributeHelper.InvokeAllMethods<UnLoadAttribute>();
    }
}