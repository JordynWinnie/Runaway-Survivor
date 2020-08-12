using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddScore(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AddScore(int scorePerSecond)
    {
        while (true)
        {
            score += scorePerSecond;
            scoreText.text = $"Score: {score}";
            yield return new WaitForSeconds(0.2f);
        }
        
    }
}
