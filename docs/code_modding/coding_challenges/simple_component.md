# 简单自定义组件

```cs
public class Timer : Component
{
    public enum TimerState
    {
        Idle,
        Running,
        Finished
    }

    private float timer;

    public TimerState State;
    public float TargetTime;  
    public Action OnFinish;

    public Timer(float targetTime)
        : base(true, false)
    {
        TargetTime = targetTime;
        State = TimerState.Idle;
    }

    public override void Update()
    {
        base.Update();

        if (!IsRunning)
            return;

        timer += Engine.RawDeltaTime;
        if (timer < TargetTime)
            return;

        OnFinish?.Invoke();
        State = TimerState.Finished;
    }

    public void Start()
    {
        if (State != TimerState.Idle)
            return;

        State = TimerState.Running;
        timer = 0f;
    }
```