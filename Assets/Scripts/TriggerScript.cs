using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public Color color;

    Transform trans;

    void Awake()
    {
        trans = GetComponent<Transform>();
        color = GetComponent<Renderer>().material.color;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void Trigger(Color col)
    {
        GetComponent<Renderer>().material.color = col;
    }

    void UnTrigger()
    {
        GetComponent<Renderer>().material.color = color;
    }
}
