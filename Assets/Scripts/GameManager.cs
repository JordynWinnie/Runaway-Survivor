using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Text attackerBar;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameUI;

    [SerializeField] private GameObject attacker;

    public int attackerBarUpperLimit = 3;
    public static float playerSpeed;
    private int score = 0;
    private float attackerBarCount = 1.5f;
    public static GameManager instance;
    public static int hiScore = 0;
    private float minSpeed = 75f;
    private bool isLost = false;

    public bool isDemoMode = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        playerSpeed = 75f;
        Time.timeScale = 1;
        gameUI.SetActive(true);
        gameOverUI.SetActive(false);
        StartCoroutine(AddScore());
        attackerBar.text = $"Attacker Bar: {attackerBarCount}/{attackerBarUpperLimit}";
        StartCoroutine(AddSpeed(0.5f));
        StartCoroutine(AddAttackerScorePerSecond());
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isDemoMode = !isDemoMode;
        }
        if (attackerBarCount <= 0)
        {
            isLost = true;
            if (score > hiScore)
            {
                hiScore = score;
            }
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            gameOverText.text = $"Game Over!\nScore: {score}\nHi-Score: {hiScore}\nPress 'R' to Restart\nPress 'Q' to Quit";

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }

        if (attackerBarCount <= 1)
        {
            ChangeAttackerState(true);
        }
        else
        {
            ChangeAttackerState(false);
        }

        attackerBarCount = Mathf.Clamp(attackerBarCount, 0, attackerBarUpperLimit);
        attackerBar.text = $"Attacker Bar: {attackerBarCount}/{attackerBarUpperLimit}";
        if (!isLost)
        {
            Time.timeScale = isDemoMode ? 0.75f : 1f;
        }
        
        playerSpeed = Mathf.Clamp(playerSpeed, minSpeed, 150f);
    }

    public void AddAttackerScore(float score)
    {
        attackerBarCount += score;
    }

    public void ChangeAttackerState(bool isEnabled)
    {
        attacker.SetActive(isEnabled);
    }

    private IEnumerator AddScore()
    {
        while (true)
        {
            score++;
            scoreText.text = $"Score: {score.ToString().PadLeft(10, '0')}";

            if (score % 1000 == 0)
            {
                attackerBarUpperLimit++;
                attackerBarUpperLimit = Mathf.Clamp(attackerBarUpperLimit, 0, 5);
            }

            if (score % 250 == 0)
            {
                minSpeed += 2.5f;
            }
            yield return new WaitForSeconds(10 / playerSpeed);
        }
    }

    private IEnumerator AddSpeed(float speedPerSecond)
    {
        while (true)
        {
            playerSpeed += speedPerSecond;
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator AddAttackerScorePerSecond()
    {
        while (true)
        {
            var rateOfChange = 300 / playerSpeed;
            attackerBarCount += 0.1f;
            attackerBarCount = (float)Math.Round((decimal)attackerBarCount, 1);
            yield return new WaitForSeconds(rateOfChange);
        }
    }
}