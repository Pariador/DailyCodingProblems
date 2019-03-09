class Event
{
    public Event(int time, EventType type)
    {
        this.Time = time;
        this.Type = type;
    }

    public int Time { get; }

    public EventType Type { get; }
}

enum EventType
{
    Start,
    Stop
}