﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float trauma = 0;

    float max_angle = 10f;
    float max_offset = 0.3f;

    Vector3 starting_position;
    Quaternion starting_rotation;

    void Start()
    {
        starting_position = transform.position;
        starting_rotation = transform.rotation;
    }

    public void Shake(float amount)
    {
        trauma += amount;
    }

    void Update()
    {
        trauma = Mathf.Clamp01(trauma - 0.01f);
    }

    void LateUpdate()
    {
        transform.position = starting_position;
        transform.rotation = starting_rotation;

        float angle = max_angle * Mathf.Pow(trauma, 2) * Random.Range(-1f, 1f);
        transform.Rotate(new Vector3(0, 0, angle));

        float offset_x = max_offset * Mathf.Pow(trauma, 2) * Random.Range(-1f, 1f);
        float offset_y = max_offset * Mathf.Pow(trauma, 2) * Random.Range(-1f, 1f);
        transform.Translate(new Vector2(offset_x, offset_y));
    }
}
