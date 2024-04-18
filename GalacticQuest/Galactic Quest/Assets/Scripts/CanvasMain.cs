using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CanvasMain : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    
    

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject fullLives;
    [SerializeField] private GameObject twoLives;
    [SerializeField] private GameObject oneLives;
    [SerializeField] private GameObject noLives;
    private float score;
    public float playerLives;

    private void Awake()
    {
        //Get the game manager script
        gameManagerScript = gameManager.GetComponent<GameManager>();

    }
    // Start is called before the first frame update
    void Start()
    {
        //Set score on canvas to score that is saved.
       score = PlayerPrefs.GetFloat("PlayerScore");
       scoreText.text = "Score: " +score;



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreUpdateCanvas(float _score)
    {
        
        score += _score;
        scoreText.text = "Score: " + score;
        gameManagerScript.ScorePlayerSave(score);

    }

    public void PlayerLivesUpdate(float _currentLives)
    {
       playerLives = _currentLives;
        if (playerLives == 3)
        {
            fullLives.SetActive(true);
            twoLives.SetActive(false);
            oneLives.SetActive(false);
            noLives.SetActive(false);
        }

        if (playerLives == 2)
        {
            fullLives.SetActive(false);
            twoLives.SetActive(true);
            oneLives.SetActive(false);
            noLives.SetActive(false);
        }

        if (playerLives == 1)
        {
            fullLives.SetActive(false);
            twoLives.SetActive(false);
            oneLives.SetActive(true);
            noLives.SetActive(false);
        }

        if (playerLives == 0)
        {
            fullLives.SetActive(false);
            twoLives.SetActive(false);
            oneLives.SetActive(false);
            noLives.SetActive(true);
        }

    }
}
