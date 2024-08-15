using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    public readonly int MazeNumber = 12;
    public GameObject[] SystemPrefabs;
    public int CurrentMaze { get; set; } = 0;
    public bool HommeIntro = false;


    void Start()
    {
        InstantiateSystemPrefabs();
        EventsManager.Instance.TimeDone.AddListener(GameOver);
        EventsManager.Instance.MazeChoosen.AddListener(OnMazeChoosen);
        EventsManager.Instance.MazeCompleted.AddListener(MazeCompleted);
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
    void OnMazeChoosen(int name)
    {
        CurrentMaze = name;
        UIManager.Instance.ToogleMazeUI();
        SceneManager.LoadScene("Maze");
        Resume();
        SoundManager.Instance.PlayMusic(SoundManager.Instance.Musics[Random.Range(0, SoundManager.Instance.Musics.Count)].name);
    }
    void ResetBoot()
    {
        UIManager.Instance.ToogleBootUI();
        SoundManager.Instance.StopMusicAudioSource();
    }
    void MazeCompleted(string itemName)
    {
        SoundManager.Instance.PlayEffects("Win");

        var starsNumber = UIManager.Instance.GetHeartsNumber;
        UIManager.Instance.SetupStars();

        ProgressManager.Instance.AddMazeItemToLearn(itemName);
        ProgressManager.Instance.AddCompletedMaze(CurrentMaze, starsNumber);
        ProgressManager.Instance.AddCompletedMaze(CurrentMaze + 1, 0);
        StartCoroutine(ProgressManager.Instance.Wait(3, () => { Instance.Win(); }));
    }
}
