using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score inst;

   public TextMeshProUGUI scoreText;
   public TextMeshProUGUI comboText;

    private int score = 0;
    private int combo = 0;
    public float comboTime = 1;
    private float lastHit = 0;

    public void Addscore(int points)
    {
        
        if(lastHit + comboTime > Time.time)
        {
            combo++;
            comboText.text = $"Combo: {combo}";
        }
        else if ( combo> 1)
        {
            score += combo;
           
           
            combo = 0;
            comboText.text = " ";

        }

        lastHit = Time.time;
        score += points;
        scoreText.text = score.ToString();
    }

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
            Destroy(gameObject);
    }
}
