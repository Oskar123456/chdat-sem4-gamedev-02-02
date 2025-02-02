using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Color color;
    public List<GameObject> triggers;

    GameObject model;
    Transform model_trans;

    Vector3 pressed_scale;
    Vector3 default_scale;
    Vector3 step_scale;
    Vector3 default_pos;
    float target_height;

    int occupants = 0;

    void Awake()
    {
    }

    void Start()
    {
        model = transform.GetChild(0).gameObject;
        model_trans = model.transform;
        model.GetComponent<Renderer>().material.color = color;

        default_scale = model_trans.localScale;
        pressed_scale = new Vector3(default_scale.x, 0.001f, default_scale.z);
        step_scale = new Vector3(0, (default_scale.y - pressed_scale.y) / 10.0f, 0);
        default_pos = model_trans.localPosition;
        target_height = default_scale.y;
    }

    void Update()
    {
        if (model_trans.localScale.y != target_height) {
            float sign = (model_trans.localScale.y > target_height) ? -1 : 1;
            model_trans.localScale += step_scale * sign;
            if (model_trans.localScale.y < pressed_scale.y)
                model_trans.localScale = pressed_scale;
            if (model_trans.localScale.y > default_scale.y)
                model_trans.localScale = default_scale;
            model_trans.localPosition = new Vector3(default_pos.x,
                    default_pos.y - (default_scale.y - model_trans.localScale.y) / 2.0f,
                    default_pos.z);
        }
    }

    void OnTriggerEnter()
    {
        occupants++;
        target_height = pressed_scale.y;
        foreach (var go in triggers)
            go.SendMessage("Trigger", color);
    }

    void OnTriggerExit()
    {
        occupants--;
        if (occupants > 0)
            return;
        target_height = default_scale.y;
        foreach (var go in triggers)
            go.SendMessage("UnTrigger");
    }

    void OnCollisionEnter()
    {
        target_height = pressed_scale.y;
        foreach (var go in triggers)
            go.SendMessage("Trigger", color);
    }

    void OnCollisionExit()
    {
        target_height = default_scale.y;
        foreach (var go in triggers)
            go.SendMessage("UnTrigger", color);
    }

    void Trigger()
    {

    }
}

















