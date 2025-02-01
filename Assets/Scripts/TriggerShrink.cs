using UnityEngine;

public class TriggerShrink : MonoBehaviour
{
    Transform trans;

    float shrink = 0;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.green;
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        trans.localScale = new Vector3(trans.localScale.x - shrink, trans.localScale.y - shrink, trans.localScale.z - shrink);
    }

    void Trigger()
    {
        shrink = 0.02f;
    }

    void UnTrigger()
    {
        shrink = 0;
    }
}
