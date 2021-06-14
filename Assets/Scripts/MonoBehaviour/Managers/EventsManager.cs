using UnityEngine;
using UnityEngine.Events;

public class EventsManager : Manager<EventsManager>
{
    internal PlayerCollideWithChar PlayerCollideWithChar;
    internal ItemToLearnClicked ItemToLearnClicked;
    internal ManagersLoaded ManagersLoaded;
    public override void Awake()
    {
        base.Awake();
        PlayerCollideWithChar = new PlayerCollideWithChar();
        ItemToLearnClicked = new ItemToLearnClicked();
        ManagersLoaded = new ManagersLoaded();
    }

}

[System.Serializable] public class PlayerCollideWithChar : UnityEvent<GameObject> { }
[System.Serializable] public class ItemToLearnClicked : UnityEvent<string> { }
[System.Serializable] public class ManagersLoaded : UnityEvent { }

