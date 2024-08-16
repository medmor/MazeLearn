using UnityEngine;

public class LockButtonImage : MonoBehaviour
{

    public int mazeNumber;
    void Start()
    {
        gameObject.SetActive(ProgressManager.Instance.LockedMaze(mazeNumber));
    }

}
