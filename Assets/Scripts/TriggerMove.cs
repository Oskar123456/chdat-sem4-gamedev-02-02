using UnityEngine;

public class TriggerMove : MonoBehaviour
{
    Transform trans;

    Vector3 up = new Vector3(0, 1, 0);
    float ms = 0;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.green;
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        trans.Translate(up * ms);
    }

    void Trigger()
    {
        ms = 0.02f;
    }

    void UnTrigger()
    {
        ms = 0;
    }
}
