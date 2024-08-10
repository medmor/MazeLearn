using UnityEngine;
using UnityEngine.SceneManagement;

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
        ResetBoot();

    }
    public void Win()
    {
        SceneManager.LoadScene("Boot");
        ResetBoot();
    }
    void OnMazeChoosen(string name)
    {
        UIManager.Instance.ToogleMazeUI();
        CurrentMaze = name;
        SceneManager.LoadScene("Maze");
        Resume();
        SoundManager.Instance.PlayMusic(SoundManager.Instance.Musics[Random.Range(0, SoundManager.Instance.Musics.Count)].name);
    }
    void ResetBoot()
    {
        UIManager.Instance.ToogleBootUI();
        SoundManager.Instance.StopMusicAudioSource();
    }
}
