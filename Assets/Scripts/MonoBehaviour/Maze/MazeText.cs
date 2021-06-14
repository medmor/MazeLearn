using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class MazeText : MonoBehaviour
{

    public TextMeshPro[] texts;
    public TMP_FontAsset FrFont;
    public TMP_FontAsset ArFont;

    void Start()
    {

        LeanTween.rotateY(gameObject, 45, 5)
            .setEase(LeanTweenType.easeShake)
            .setLoopClamp()
            .setRepeat(-1);
    }

    public void SetTexts(string text)
    {
        foreach (var t in texts)
        {
            if (Regex.IsMatch(text, "^[a-zA-Z]*$"))
                t.font = FrFont;
            else
            {
                t.font = ArFont;
                t.fontSize = 14;
            }
            t.text = text;
        }
    }

    public char GetChar()
    {
        return texts[0].text[0];
    }

}
