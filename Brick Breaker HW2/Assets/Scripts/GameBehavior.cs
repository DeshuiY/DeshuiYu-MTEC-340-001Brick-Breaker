using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
 
    public static GameBehavior Instance { get; private set; }


    private int _score;


    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            UpdateScoreUI();  
        }
    }

    [SerializeField] private TextMeshProUGUI _scoreTextUI;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void UpdateScoreUI()
    {
        if (_scoreTextUI != null)
        {
            _scoreTextUI.text = "Score: " + _score;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}