using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoor : MonoBehaviour
{
    public Color color;
    public List<GameObject> triggers;

    public int s = 2;
    public int dir = 0;

    int blink_frames = 0;
    Color blink_color;

    Transform trans;

    Vector3 pressed_scale;
    Vector3 default_scale;
    Vector3 step_scale;
    Vector3 default_pos;
    float target_length;

    void Start()
    {
        trans = GetComponent<Transform>();
        color = GetComponent<Renderer>().material.color;
        blink_color = new Color(color.r, color.g, color.b * 1.2f, color.a / 2.0f);
        default_scale = new Vector3(trans.localScale.x, trans.localScale.y, trans.localScale.z);
        pressed_scale = new Vector3(0.001f, default_scale.y, default_scale.z);
        step_scale = new Vector3((default_scale.x - pressed_scale.x) / 10.0f, 0, 0);
        default_pos = trans.localPosition;
        target_length = default_scale.y;
    }

    void Update()
    {
        if (s < 1) {
            target_length = pressed_scale.x;
        }

        else {
            target_length = default_scale.x;
        }

        if (trans.localScale.x != target_length) {
            float sign = (trans.localScale.x > target_length) ? -1 : 1;
            trans.localScale += step_scale * sign;
            if (trans.localScale.x < pressed_scale.x)
                trans.localScale = pressed_scale;
            if (trans.localScale.x > default_scale.x)
                trans.localScale = default_scale;
            if (dir == 0) {
                trans.localPosition = new Vector3(default_pos.x - (default_scale.x - trans.localScale.x) / 2.0f,
                        default_pos.y, default_pos.z);
            }
            else {
                trans.localPosition = new Vector3(default_pos.x,
                        default_pos.y, default_pos.z - (default_scale.x - trans.localScale.x) / 2.0f);
            }
        }

        if (blink_frames > 0) {
            blink_frames--;
            if (blink_frames > 1)
                GetComponent<Renderer>().material.color = blink_color;
            else
                GetComponent<Renderer>().material.color = color;
        }

    }

    void Trigger(Color col)
    {
        s--;
        blink_frames += 10;
        /* Debug.Log(s); */
    }

    void UnTrigger()
    {
        s++;
        blink_frames += 10;
        /* Debug.Log(s); */
    }
}
