﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    int team_A_score = 0;
    int team_B_score = 0;

    public void TeamAScores(int points)
    {
        team_A_score += points;
        transform.Find("Team A BG/Score").GetComponent<Text>().text = team_A_score.ToString();
    }

    public void TeamBScores(int points)
    {
        team_B_score += points;
        transform.Find("Team B BG/Score").GetComponent<Text>().text = team_B_score.ToString();
    }
}
