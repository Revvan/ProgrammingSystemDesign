using UnityEngine;

public class Manager_Game : MonoBehaviour
{
    private static Manager_Game instance;
    public static Manager_Game Instance => instance;


    [SerializeField] private int currentPlayerScore = 0;
    [SerializeField] private int pointsToWin = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    
    public void CheckWin()
    {
        if (_GetPlayerScore() >= pointsToWin)
        {
            Manager_Score.Instance.UpdateScore(_GetPlayerScore());
            Manager_Scenes.Instance.ChangeActiveScene();
            currentPlayerScore = 0;
        } 
    }

    public void IncreaseScore(int score)
    {
        currentPlayerScore += score;
    }

    public void DecreaseScore(int score)
    {
        currentPlayerScore -= score;
    }

    public int _GetPlayerScore() => currentPlayerScore;
    
}
