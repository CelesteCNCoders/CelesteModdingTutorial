# Monocle

`Monocle` 是蔚蓝的底层引擎, 由 `matt` 开发的一个基于 `XNA` 框架的 2D 游戏引擎.     
我们编写 Code Mod 实际上是在这个引擎上工作, 因此需要对这个有一些了解.

`XNA` 只提供了基础的底层 API, 而 `Monocle` 在它之上进行了封装, 提供了场景管理与渲染, 游戏逻辑相关的更易用的工具.

!!!info
    `Monocle` 后续为了跨平台使用了 `FNA` 与 `MonoGame`, 两者均是 `XNA` 的一个跨平台的重实现.

这一节会简单介绍 `Monocle` 的架构与生命周期. <del>实际上编写蔚蓝 CodeMod 也只用了解这么多(草</del>
