using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

   
   [SerializeField] private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null || instance!=this)
            instance = this;
        else
            Destroy(instance);

        DontDestroyOnLoad(this);
    }


    public void SetScore(int score)
    {
        scoreText.text = "Score: "+score.ToString();
    }
   
}
