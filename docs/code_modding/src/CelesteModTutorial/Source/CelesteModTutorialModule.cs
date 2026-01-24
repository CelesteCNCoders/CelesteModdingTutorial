namespace Celeste.Mod.CelesteModTutorial;

public sealed class CelesteModTutorialModule : EverestModule
{
    public static CelesteModTutorialModule Instance { get; private set; }

    public override Type SettingsType => typeof(CelesteModTutorialSettings);
    public static CelesteModTutorialSettings Settings => (CelesteModTutorialSettings)Instance._Settings!;


    public override void Load()
    {
        Instance = this;
        Logger.Log(LogLevel.Info, "CelesteModTutorial", "Hello, Celeste!");
    }

    public override void Unload()
    {
    }
}