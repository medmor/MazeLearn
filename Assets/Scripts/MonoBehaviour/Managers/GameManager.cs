using UnityEngine;
using UnityEngine.SceneManagement;
//using System;

public class GameManager : Manager<GameManager>
{
    public readonly int MazeNumber = 12;
    public GameObject[] SystemPrefabs;
    public string CurrentMaze { get; set; } = "Maze6";
    public bool HommeIntro = false;


    void Start()
    {
        InstantiateSystemPrefabs();
        EventsManager.Instance.TimeDone.AddListener(GameOver);
        EventsManager.Instance.MazeChoosen.AddListener(OnMazeChoosen);
    }

    void InstantiateSystemPrefabs()
    {
        for (int i = 0; i < SystemPrefabs.Length; ++i)
        {
            Instantiate(SystemPrefabs[i]);
        }
        SoundManager.Instance.PlayEffects("Intro");
    }



    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        SoundManager.Instance.PlayEffects("Lose");
        SceneManager.LoadScene("Boot");
        UIManager.Instance.mazeUI.SetActive(false);
        UIManager.Instance.introUI.SetActive(true);
        SoundManager.Instance.StopMusicAudioSource();
    }
    public void Win()
    {
        SceneManager.LoadScene("Boot");
        UIManager.Instance.mazeUI.SetActive(false);
        UIManager.Instance.introUI.SetActive(true);
        UIManager.Instance.StarsContainer.gameObject.SetActive(false);
        SoundManager.Instance.StopMusicAudioSource();
    }
    void OnMazeChoosen(string name)
    {
        print(name);
        UIManager.Instance.choicesMenu.SetActive(false);
        UIManager.Instance.mazeUI.SetActive(true);
        CurrentMaze = name;
        SceneManager.LoadScene("Maze");
        Resume();
        SoundManager.Instance.PlayMusic(SoundManager.Instance.Musics[Random.Range(0, SoundManager.Instance.Musics.Count)].name);
    }
}
