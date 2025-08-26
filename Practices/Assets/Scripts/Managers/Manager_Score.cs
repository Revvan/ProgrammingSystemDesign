using UnityEngine;

public class Manager_Score : MonoBehaviour
{
    private static Manager_Score instance;
    public static Manager_Score Instance => instance;

    [SerializeField] private int storedScore;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void UpdateScore(int score)
    {
        storedScore += score;
    }
}