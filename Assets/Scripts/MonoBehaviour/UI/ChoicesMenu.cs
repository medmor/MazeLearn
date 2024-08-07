﻿using UnityEngine;
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
            var button = Instantiate(ButtonPref);
            button.transform.SetParent(grid);
            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                GoToMaze(numb.ToString());
                UIManager.Instance.choicesMenu.SetActive(false);
                UIManager.Instance.mazeUI.SetActive(true);
            });

            button.GetComponentInChildren<Text>().text = numb.ToString();

            var locked = ProgressManager.Instance.LockedMaze(numb);

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
        if (ProgressManager.Instance.LockedMaze(int.Parse(mazeNumber)))
            return;
        SoundManager.Instance.PlayEffects("Click");
        GameManager.Instance.CurrentMaze = "Maze" + mazeNumber;
        GameManager.Instance.SwitchScene("Maze");
    }
}
