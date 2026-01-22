using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Mod.CelesteModTutorial;

public class CelesteModTutorialSettings : EverestModuleSettings
{
    [DefaultButtonBinding(0, Keys.None)]
    public ButtonBinding SampleBinding { get; set; }
}
