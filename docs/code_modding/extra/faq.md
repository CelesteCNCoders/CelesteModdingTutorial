## Everest有什么用

因为要做 Mod, 就得对原版游戏代码作出修改, 而每个人的改法不同, 势必会产出多个不同的 Mod 加载器(如图中的Celeste0, Celeste1, Everest), 既不利于传播, 又很浪费生产力, 那怎么办, 增加一层抽象,
由 Everest 帮我们把脏活累活儿干了, 我们只需要使用 Everest 和原版提供的接口就可以很方便的实现各种功能

![why_everest](./images/why_everest.png)

## 什么是 .NET Core Everest?

老的c#框架称为`.NET Framework`, 只能运行在windows平台上

而新的c#框架称为`.NET Core`, 能运行在任意平台上

所以`.NET Core Everest`自然也就是基于`.NET Core`框架实现的Everest(更新换代了), 从 4465 版本往后的Everest都是`.NET Core Everest`
