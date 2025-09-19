# 私有访问

## DynamicData

通常, 你可能需要访问一个私有方法或者私有字段, 首先最容易想到的当然是反射, 不过 MonoMod 为我们提供了一个更好的东西:
`DynamicData` 类, 例如访问玩家的私有字段 `onGround`:

```cs
DynamicData playerData = DynamicData.For(player);
bool onGround = playerData.Get<bool>("onGround");
```

修改也十分简单, 例如修改玩家的最大下落速度:

```cs
playerData.Set("maxFall", 660f);
```

调用私有方法同理, 参数也只需作为 params 参数传递:

```cs
playerData.Invoke("Duck");

bool checkResult = (bool)playerData.Invoke("DreamDashCheck", Vector2.UnitX);
```

对于静态类, 只需要简单的更改获取 `DynamicData` 的方式:

```cs
DynamicData inputData = new DynamicData(typeof(Input));
```

随后静态方法, 字段, 属性的访问也与实例的相同.  

当字符串指定的成员不存在时, 注意并不会报错, 对于其的非泛型 `Get` 方法会简单地返回 null 值, 对于值类型泛型 `Get` 方法会引发空引用异常, 对于引用类型泛型 `Get` 方法返回 null.
不过对于 `Set` 方法, 如果指定的成员不存在时它会将这个成员 "粘附" 到对象上, 就像给对象动态加了一条字段一样, 随后使用 `Get` 方法也能获取到这个值,
你可以使用将这个行为当 "动态添加字段" 一样使用. 例如:

```cs
DynamicData dd = DynamicData.For(player);
dd.Set("mcm_attached", "some attached data...");


// ...一些其他地方
string data = dd.Get<string>("mcm_attached");
Logger.Log(LogLevel.Info, "MyCelesteMod", $"data is {data}");
```

不过记得添加自己 mod 独特的命名前缀以防重名, `DynamicData` 在不同 mod 间是共享的.

## FastReflectionHelper
