using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{

    void Start()
    {

        GetComponent<Button>().onClick.AddListener(() =>
        {
            SoundManager.Instance.PlayEffects("Click");
            UIManager.Instance.choicesMenu.SetActive(true);
            UIManager.Instance.mazeUI.SetActive(false);
        });
    }

}
