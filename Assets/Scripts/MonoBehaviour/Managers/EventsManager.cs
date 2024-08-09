using UnityEngine;
using UnityEngine.Events;

public class EventsManager : Manager<EventsManager>
{
    internal PlayerCollideWithChar PlayerCollideWithChar;
    internal TimeDone TimeDone;
    internal MazeChoosen MazeChoosen;
    public override void Awake()
    {
        base.Awake();
        PlayerCollideWithChar = new PlayerCollideWithChar();
        TimeDone = new TimeDone();
        MazeChoosen = new MazeChoosen();
    }

}

[System.Serializable] public class PlayerCollideWithChar : UnityEvent<GameObject> { }
[System.Serializable] public class TimeDone : UnityEvent { }
[System.Serializable] public class MazeChoosen : UnityEvent<string> { }

