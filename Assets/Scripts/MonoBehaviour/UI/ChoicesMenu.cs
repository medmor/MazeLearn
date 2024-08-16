using UnityEngine;
using UnityEngine.UI;

public class ChoicesMenu : MonoBehaviour
{
    public Transform grid;
    public GameObject ButtonPref;
    public GameObject starPref;

    public void InstantiateButtons()
    {
        foreach (Transform child in grid)
        {
            Destroy(child.gameObject);
        }
        for (var i = 0; i < GameManager.Instance.MazeNumber; i++)
        {
            var numb = i;
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
                EventsManager.Instance.MazeChoosen.Invoke(numb);
            });

            button.GetComponentInChildren<Text>().text = (numb + 1).ToString();

            button.transform.GetChild(1).GetComponent<Image>().enabled = locked;

            var stars = button.transform.GetChild(2);
            stars.gameObject.SetActive(!locked);
            if (!locked)
            {
                var starsNumber = ProgressManager.Instance.GetMazeStars(numb);
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
