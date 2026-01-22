# 输入获取

在编写 Mod 时, 我们有时会需要获取玩家的输入, 这里会简单介绍.

## Input

静态类 `Input` 中预定义了蔚蓝中常用的操作映射:

```cs
// 菜单相关
public static VirtualButton ESC;
public static VirtualButton Pause;
public static VirtualButton MenuLeft;
public static VirtualButton MenuRight;
public static VirtualButton MenuUp;
public static VirtualButton MenuDown;
public static VirtualButton MenuConfirm;
public static VirtualButton MenuCancel;
public static VirtualButton MenuJournal;

// 游戏相关
public static VirtualButton QuickRestart;
public static VirtualButton Jump;
public static VirtualButton Dash;
public static VirtualButton Grab;
public static VirtualButton Talk;
public static VirtualButton CrouchDash;
```

可以看到这些的类型是 `VirtualButton`, 可以理解为物理按键的虚拟映射, 把不同的输入映射至一个特定的操作, 或者也可以理解为绑键.       
比如你可以把键盘的 ++c++ 与 ++space++ 或是其他奇怪的按键都映射至跳跃.

我们可以检查它们的这些属性获取输入状态:     
- `Check`: 检查按键在当前帧是否被按下, 持续检测, 只要按键被按下就会返回 `true`.                 
- `Pressed`: 检查按键在当前帧是否被按下, 瞬间检测, 只有按键被第一次按下的那帧会返回 `true`.        
- `Released`: 检查按键在当前帧是否被释放, 瞬间检测, 只有按键被释放的那帧会返回 `true`.        

下面是一个当玛德琳跳跃时就让玛德琳爆炸的 Trigger 例子:
```cs
[CustomEntity("MyCelesteMod/SampleTrigger")]
public class SampleTrigger : Trigger
{
    public SampleTrigger(EntityData data, Vector2 offset) 
        : base(data, offset)
    {
    }

    public override void OnStay(Player player)
    {
        base.OnStay(player);

        // 如果玛德琳在 SampleTrigger 内跳跃就让玛德琳爆炸
        if (Input.Jump.Pressed)
            player.Die(Vector2.Zero);
    }
}
```

!!!info
    蔚蓝中的预输入, 也就是输入缓冲是通过 `float VirtualButton.BufferTime` 实现的.       
    通常蔚蓝预定义的按键的输入缓冲都是 `0.08f`, 约为 5 帧. 

    有时候我们会希望在检测到按键按下后清空输入缓冲以防止重复触发或逻辑冲突, 可以调用这些方法:       
    - `ConsumeBuffer()`: 把 `BufferTime` 设为 `0f` 清空输入缓冲.         
    - `ConsumePress()`: 把 `BufferTime` 设为 `0f` 清空输入缓冲, 并让当前帧后续所有的瞬间按键检测都返回 `false`.

除了按键输入, 有时我们也希望获取输入的方向, `Input` 中提供了这些:

```cs
// X轴输入
public static VirtualIntegerAxis MoveX;
// Y轴输入
public static VirtualIntegerAxis MoveY;
// 全向输入
public static VirtualJoystick Aim;
```

这些都有 `Value` 与 `PreviousValue` 属性, 表示当前帧以及上一帧输入的方向.     

`VirtualIntegerAxis` 的上述属性类型为 `int`, 取值为 `-1, 0, 1`. 没有移动时返回 `0`.
对于 `MoveX`, 输入方向向左时返回 `-1`, 向右时返回 `1`.      
对于 `MoveY`, 输入方向向上时返回 `-1`, 向下时返回 `1`.      

`VirtualJoystick` 的上述属性类型为 `Vector2`, 分量 `X` 与 `Y` 的取值范围在 `[-1, 1]` 之间.
!!!info
    `Input` 内也提供了获取八向输入的方法 `Vector2 GetAimVector(Facings defaultFacing = Facings.Right)`, 返回的是归一化后的方向向量.  
    参数 `defaultFacing` 表示没有方向输入时分量 `X` 的取值, `Facings.Right` 返回 `(1f, 0f)`,  `Facings.Left` 返回 `(-1f, 0f)`.

## 自定义按键映射

我们也可以向 Mod 中提供自定义按键映射, 通常是在我们 Mod 中的 `Settings` 里定义:

```cs title="MyCelesteModSettings.cs"
public class MyCelesteModSettings : EverestModuleSettings
{
    [DefaultButtonBinding(0, Keys.A)]
    public ButtonBinding SampleBinding { get; set; }
}
```

### DefaultButtonBindingAttribute

`DefaultButtonBindingAttribute` 特性用于标记 `Settings` 中类型为 `ButtonBinding` 的属性为自定义按键映射.        

这个特性有两个构造函数重载:

```cs 
public class DefaultButtonBindingAttribute : Attribute
{
    // button 表示手柄的按键, 设为 0 表示不进行设置
    // key 表示键盘的按键, 设为 Keys.None 表示不进行设置
    public DefaultButtonBindingAttribute(Buttons button, Keys key)

    // 这个重载用于指定多个默认映射
	public DefaultButtonBindingAttribute(Buttons[] buttons, Keys[] keys)
}
```

`Everest` 会自动查找并在 `EverestModule.OnInputInitialize()` 调用时进行注册. 这是一个虚方法, 但通常我们并不需要重写.      

在 `Settings` 里定义完成后就可以进行使用了, 与使用 `VirtualButton` 相同:

```cs
if (MyCelesteModModule.Settings.SampleBinding.Pressed)
{
    Logger.Info("MyCelesteMod", "SampleBinding Pressed!");
    MyCelesteModModule.Settings.SampleBinding.ConsumeBuffer();
}
```

也可以在 `Mod 设置` 中进行更改:

![sample_binding](images/input_handling/sample_binding.png)

!!!info
    此外静态类 `TextInput` 提供了监听原始键盘输入的事件 `event Action<char> OnInput`, 有需要可以订阅这个事件.