using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProgressManager : Manager<ProgressManager>
{
    public readonly string MazeProgressKey = "MazesProgress";
    public readonly string MazeItemsToLearnKey = "MazeItemsToLearn";

    private List<int> MazeProgress = new List<int>();
    private readonly List<string> MazeItemsToLearn = new List<string>();

    public void Start()
    {
        if (PlayerPrefs.HasKey(MazeProgressKey))
            MazeProgress = GetMazeProgress().Split(',').ToList().Select(x => int.Parse(x)).ToList();
        else
            ResetMazeProgress();
    }

    public void SetMazeProgress()
    {
        PlayerPrefs.SetString(MazeProgressKey, string.Join(",", MazeProgress));
        PlayerPrefs.Save();
    }

    public void AddCompletedMaze(int index, int stars)
    {


        if (index > MazeProgress.Count - 1)
        {
            MazeProgress.Add(stars);
        }
        else
        {
            MazeProgress[index] = stars;
        }
        SetMazeProgress();
    }

    public string GetMazeProgress()
    {
        return PlayerPrefs.GetString(MazeProgressKey);
    }

    public void ResetMazeProgress()
    {
        MazeProgress = new List<int>() { 0 };
        SetMazeProgress();
    }

    public bool LockedMaze(int mazeNumber)
    {
        return mazeNumber > MazeProgress.Count - 1;
    }

    public int GetMazeStars(int mazeNumber)
    {
        if (mazeNumber > MazeProgress.Count - 1) return 0;
        return MazeProgress[mazeNumber];
    }

    public void AddMazeItemToLearn(string item)
    {
        MazeItemsToLearn.Add(item);
    }

    public List<string> GetIMazeItemsToLearn()
    {
        return MazeItemsToLearn;
    }


    public IEnumerator Wait(float seconds, LambdaArgument lambda)
    {
        yield return new WaitForSeconds(seconds);
        lambda();
    }
    public delegate void LambdaArgument();


}
