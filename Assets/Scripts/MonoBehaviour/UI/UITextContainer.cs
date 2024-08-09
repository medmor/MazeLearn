using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UITextContainer : MonoBehaviour
{
    public GameObject TextSlotPref;

    public void SpawnUIChars(string name, List<GameObject> uIChars)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (var i = 0; i < name.Length; i++)
        {
            var txt = Instantiate(TextSlotPref);
            txt.transform.SetParent(transform);
            txt.GetComponentInChildren<TextMeshProUGUI>().text = name[i].ToString();
            uIChars.Add(txt);
        }
    }
}
