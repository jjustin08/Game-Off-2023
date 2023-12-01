using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Contest : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Score1;
    [SerializeField] private TextMeshProUGUI Score2;
    [SerializeField] private TextMeshProUGUI Score3;
    [SerializeField] private TextMeshProUGUI Score4;
    [SerializeField] private GameObject background;



    [SerializeField] private TextMeshProUGUI TotalScore;

    private float counter;
    private float counterInterval = 2;

    private bool isActive = false;





    private int numScore1 = -1;
    private int numScore2 = -1;
    private int numScore3 = -1;
    private int numScore4 = -1;
    private float totalScore = -1;

    public void ActiveContest()
    {
        background.SetActive(true);
        isActive = true;
    }


    private void FixedUpdate()
    {
        if(isActive)
        StartScoring();
    }

    private int CalculateScore()
    {
        CharacterStats stats = Player.Instance.GetCharacterStats();

        int score = 10;

        float arms = stats.GetArms();
        float legs = stats.GetLegs();
        float shoulders = stats.GetShoulders();
        float back = stats.GetBack();  
        float chest = stats.GetChest();

        if(AreFloatsInRange(arms, legs, 20))
        {
            score -= 1;
        }
        if(AreFloatsInRange(shoulders, arms, 5))
        {
            score -= 1;
        }
        if(AreFloatsInRange(back, shoulders, 10))
        {
            score -= 1;
        }
        if(AreFloatsInRange(back, chest, 25))
        {
            score -= 1;
        }

        if(stats.CalculateWeight() < 200)
        {
            score -= 1;
        }
        if(stats.CalculateWeight() < 175)
        {
            score -= 1;
        }
        if(stats.CalculateWeight() < 150)
        {
            score -= 1;
        }
        if(stats.CalculateWeight() < 125)
        {
            score -= 1;
        }
        

        return score;
    }



    public void StartScoring()
    {
        int score = CalculateScore();
        counter += Time.deltaTime;
        float counterMax = 2;

        Score1.gameObject.SetActive(true);
        if (ShuffleNumbers(Score1, counterMax, score))
        {
            if(numScore1 == -1)
            {
                int randomNum = Random.Range(score - 2, score);
                numScore1 = randomNum;
                totalScore += randomNum;
                //show proper score
                Score1.text = randomNum.ToString();
            }
            
            counterMax += counterInterval;
            Score2.gameObject.SetActive(true);
            if (ShuffleNumbers(Score2, counterMax, score))
            {
                if (numScore2 == -1)
                {
                    int randomNum = Random.Range(score - 2, score);
                    numScore2 = randomNum;
                totalScore += randomNum;
                    //show proper score
                    Score2.text = randomNum.ToString();
                }

                counterMax += counterInterval;
                Score3.gameObject.SetActive(true);
                if (ShuffleNumbers(Score3, counterMax, score))
                {

                    if (numScore3 == -1)
                    {
                        int randomNum = Random.Range(score - 2, score);
                        numScore3 = randomNum;
                totalScore += randomNum;
                        //show proper score
                        Score3.text = randomNum.ToString();
                    }
                    counterMax += counterInterval;
                    Score4.gameObject.SetActive(true);
                    if (ShuffleNumbers(Score4, counterMax, score))
                    {

                        if (numScore4 == -1)
                        {
                            int randomNum = Random.Range(score - 2, score);
                            numScore4 = randomNum;
                totalScore += randomNum;
                            //show proper score
                            Score4.text = randomNum.ToString();
                        }
                        counterMax += counterInterval;

                        totalScore = totalScore / 40;
                        TotalScore.gameObject.SetActive(true);
                        TotalScore.text = totalScore.ToString();
                    }
                }
            }
            
        }
    }

    private bool ShuffleNumbers(TextMeshProUGUI text, float maxCount, int score)
    {
        if(counter >= maxCount)
        {


            return true;
        }
        else
        {
            int randomNum = Random.Range(0, 10);
            text.text = randomNum.ToString();
            return false;
        }
    }


    bool AreFloatsInRange(float float1, float float2, float range)
    {
        float difference = Mathf.Abs(float1 - float2);

        return difference <= range;
    }
}
