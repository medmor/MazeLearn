
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonClick : MonoBehaviour
{


    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            UIManager.Instance.introUI.SetActive(false);
            UIManager.Instance.choicesMenu.SetActive(true);
        });
    }
}
