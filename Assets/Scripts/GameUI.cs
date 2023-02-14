using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    public void UpdateScoreUI(int value)
    {
        scoreText.text = string.Format("Score : {0}", value);
    }
}
