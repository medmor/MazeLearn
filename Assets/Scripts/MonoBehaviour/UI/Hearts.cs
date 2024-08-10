using UnityEngine;

public class Hearts : MonoBehaviour
{
    [SerializeField] GameObject HeartPrefab;
    public void ResetHearts()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(HeartPrefab, transform);
        }
    }
}
