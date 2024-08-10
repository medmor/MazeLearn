using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{

    void Start()
    {

        GetComponent<Button>().onClick.AddListener(() =>
        {
            GameManager.Instance.Pause();
            SoundManager.Instance.PlayEffects("Click");
            UIManager.Instance.ToogleBootUI();
            SoundManager.Instance.StopMusicAudioSource();
        });
    }

}
