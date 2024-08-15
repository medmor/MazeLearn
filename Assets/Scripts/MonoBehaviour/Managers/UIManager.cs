
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager<UIManager>
{

    [SerializeField] GameObject introUI;
    [SerializeField] GameObject choicesMenu;
    [SerializeField] GameObject mazeUI;
    [SerializeField] UITextContainer ArUITextContainer;
    [SerializeField] UITextContainer FrUITextContainer;
    [SerializeField] UITextContainer EnUITextContainer;
    [SerializeField] MazeTimer MazeTimer;
    [SerializeField] StarsContainer StarsContainer;
    [SerializeField] ChoicesMenu ChoicesMenu;
    [SerializeField] Hearts Hearts;

    public void ToogleBootUI()
    {
        mazeUI.SetActive(false);
        introUI.SetActive(true);
        StarsContainer.gameObject.SetActive(false);
        Hearts.ResetHearts();
    }

    public void ToogleMazeUI()
    {
        choicesMenu.SetActive(false);
        mazeUI.SetActive(true);
    }

    public void ToogleChoicesMenu()
    {
        introUI.SetActive(false);
        choicesMenu.SetActive(true);
    }

    public void SpawnUITexts(string arName, string frName, string enName, List<GameObject> uiChars)
    {
        ArUITextContainer.SpawnUIChars(arName, uiChars);
        FrUITextContainer.SpawnUIChars(frName, uiChars);
        EnUITextContainer.SpawnUIChars(enName, uiChars);
    }

    public int GetHeartsNumber => Hearts.transform.childCount;

    public void SetupStars()
    {
        StarsContainer.SpawnStars(Hearts.transform.childCount);
        StarsContainer.Tween();
    }

    public bool DecrementHeart()
    {
        Destroy(Hearts.transform.GetChild(0).gameObject);
        if (Hearts.transform.childCount == 1)
        {
            return true;
        }
        return false;
    }
    public void ResetHearts()
    {
        Hearts.ResetHearts();
    }

    public void InstantiateButtons()
    {
        ChoicesMenu.InstantiateButtons();
    }

}
