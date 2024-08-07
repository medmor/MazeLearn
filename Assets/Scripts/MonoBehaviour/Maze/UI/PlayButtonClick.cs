
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonClick : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject introContainer;

    public void Start()
    {
        playButton.onClick.AddListener(() => { introContainer.SetActive(false); });
    }
}
