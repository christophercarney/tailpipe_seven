﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool passing = false;

    Player pass_destination;

    float orig_ball_speed = 0.3f;
    float current_ball_speed;

    public void Pass(Player new_player)
    {
        current_ball_speed = orig_ball_speed;

        passing = true;
        pass_destination = new_player;
    }
	
	void Update ()
    {
        if (passing)
        {
            float current_distance = Vector2.Distance(transform.position, pass_destination.transform.position);
            if (current_distance < 0.1f)
            {
                passing = false;
                FixPositionFacing(pass_destination);
                return;
            }

            current_ball_speed = Mathf.Clamp(0.92f * current_ball_speed, orig_ball_speed * 0.1f, orig_ball_speed);
            transform.position = Vector2.MoveTowards(transform.position, pass_destination.transform.position, current_ball_speed);
            transform.Rotate(new Vector3(0, 0, 20f));
        }
	}

    public void FixPositionFacing(Player player)
    {
        switch (player.facing)
        {
            case SpriteFacing.SE:
                transform.localPosition = new Vector3(0.06f, -0.03f, -0.25f);
                break;
            case SpriteFacing.SW:
                transform.localPosition = new Vector3(-0.06f, -0.03f, -0.25f);
                break;
            case SpriteFacing.NE:
                transform.localPosition = new Vector3(0.06f, -0.03f, 0.25f);
                break;
            case SpriteFacing.NW:
                transform.localPosition = new Vector3(-0.06f, -0.03f, 0.25f);
                break;
        }
    }
}
