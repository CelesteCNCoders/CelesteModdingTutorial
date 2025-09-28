# Tracker

`Tracker` 由 `Scene` 管理, 在我们使用 `Scene.Add(new Entity())` 的时候, 会通过 `EntityList` 向 `Tracker` 加入 `Entity` (当然还有 `Component`, 但在后面只提及 `Entity`).  
所有需要被 `Tracked` (或者说被记录) 的 `Entity` 需要加上 `[Tracked]` 特性.  
你还可以通过 `[TrackedAs(typeof(xxx))]` 特性让一个 `A` 类型被同时当作 `B` 类型, 这样就可以使用 `Scene.Tracker.GetEntities<B>()` 来同时拿到 `A` 和 `B` 了
(这个特性作为 Everest 的一个拓展存在).