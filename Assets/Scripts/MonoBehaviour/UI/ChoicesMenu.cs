using UnityEngine;
using UnityEngine.UI;

public class ChoicesMenu : MonoBehaviour
{
    public Transform grid;
    public GameObject ButtonPref;
    public GameObject starPref;

    public void Start()
    {
        InstantiateButtons();
    }

    public void InstantiateButtons()
    {
        for (var i = 0; i < GameManager.Instance.MazeNumber; i++)
        {
            var numb = i + 1;
            var locked = ProgressManager.Instance.LockedMaze(numb);
            var button = Instantiate(ButtonPref);
            button.transform.SetParent(grid);
            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (locked)
                {
                    return;
                }
                SoundManager.Instance.PlayEffects("Click");
                EventsManager.Instance.MazeChoosen.Invoke("Maze" + numb.ToString());
            });

            button.GetComponentInChildren<Text>().text = numb.ToString();

            button.transform.GetChild(1).GetComponent<Image>().enabled = locked;

            var stars = button.transform.GetChild(2);
            stars.gameObject.SetActive(!locked);
            if (!locked)
            {
                var starsNumber = ProgressManager.Instance.GetMazeStars(numb.ToString());
                for (var j = 0; j < starsNumber; j++)
                {
                    var star = Instantiate(starPref);
                    star.transform.SetParent(stars);
                }
            }

        }
    }
    public void GoToMaze(string mazeNumber)
    {

    }
}
