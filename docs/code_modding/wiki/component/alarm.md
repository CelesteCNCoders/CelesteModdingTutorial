# Alarm

顾名思义, 它就是个'闹钟', 它允许你设定一个时间并在时间结束后做一些事情, 其使用起来很简单:
```cs
Alarm alarm = Alarm.Create(Alarm.AlarmMode.Oneshot, OnAlarm, 2f, false);
Add(alarm);
alarm.Start();

static void OnAlarm()
{
    Logger.Log(LogLevel.Info, "Test", "123");
}
```

- 第一个参数 `AlarmMode` 与 `Tween.TweenMode` 的基本一致, 这里就不赘述了
- 第二个参数表示时间到后的回调函数
- 第三个参数表示时间有多长
- 第四个参数也与 tween 类似, 表示是否希望自动调用 `Start` 方法

除了在第三个参数处设置时间长度外, `Start` 方法也允许我们传入一个时间长度, 这会在你需要一个不定长的闹钟的时候很有用.  
除此之外, `Alarm` 也有类似于 `Tween.Set` 的方法直接作用与 `Entity` 上, 参数也与其构造函数相同:
```cs
// 不过这里 AlarmMode 反而被 matt 放到最后去了
Alarm.Set(this, 2f, OnAlarm, Alarm.AlarmMode.Oneshot).Start();
```
