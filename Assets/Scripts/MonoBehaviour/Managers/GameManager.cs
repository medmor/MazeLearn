using UnityEngine;
using UnityEngine.SceneManagement;
//using System;

public class GameManager : Manager<GameManager>
{
    public readonly int MazeNumber = 12;

    public GameObject[] SystemPrefabs;
    public string CurrentMaze { get; set; } = "Maze6";
    public bool HommeIntro = false;
    // public GameObject MazeChoiceUI;


    void Start()
    {
        InstantiateSystemPrefabs();
        // Instantiate(MazeChoiceUI);
    }
    void InstantiateSystemPrefabs()
    {
        for (int i = 0; i < SystemPrefabs.Length; ++i)
        {
            Instantiate(SystemPrefabs[i]);
        }
        SoundManager.Instance.PlayEffects("Intro");
    }

    public void SwitchScene(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Single)
            .completed += OnSceneLoadCompleted;

    }

    void OnSceneLoadCompleted(AsyncOperation ao)
    {
        var name = SceneManager.GetActiveScene().name;
        if (name == "Maze")
            SoundManager.Instance.PlayMusic(SoundManager.Instance.Musics[Random.Range(0, SoundManager.Instance.Musics.Count)].name);
        else
        {
            SoundManager.Instance.StopMusicAudioSource();
            // Instantiate(MazeChoiceUI);
        }
    }


}
