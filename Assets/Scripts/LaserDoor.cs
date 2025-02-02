using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoor : MonoBehaviour
{
    public Color color;
    public List<GameObject> triggers;

    int s = 2;

    Transform trans;

    Vector3 pressed_scale;
    Vector3 default_scale;
    Vector3 step_scale;
    Vector3 default_pos;
    float target_length;

    void Start()
    {
        trans = GetComponent<Transform>();
        GetComponent<Renderer>().material.color = color;

        default_scale = trans.localScale;
        pressed_scale = new Vector3(0.001f, default_scale.y, default_scale.z);
        step_scale = new Vector3(0, (default_scale.y - pressed_scale.y) / 10.0f, 0);
        default_pos = trans.localPosition;
        target_length = default_scale.y;
    }

    void Update()
    {
        if (s < 1) {
            target_length = pressed_scale.x;
        }

        if (trans.localScale.x != target_length) {
            float sign = (trans.localScale.x > target_length) ? -1 : 1;
            trans.localScale += step_scale * sign;
            if (trans.localScale.x < pressed_scale.x)
                trans.localScale = pressed_scale;
            if (trans.localScale.x > default_scale.x)
                trans.localScale = default_scale;
            trans.localPosition = new Vector3(default_pos.x - (default_scale.x - trans.localScale.x) / 2.0f,
                    default_pos.y,
                    default_pos.z);
        }

    }

    void Trigger()
    {
        s--;
        Debug.Log(s);
    }

    void UnTrigger()
    {
        s++;
        Debug.Log(s);
    }
}
