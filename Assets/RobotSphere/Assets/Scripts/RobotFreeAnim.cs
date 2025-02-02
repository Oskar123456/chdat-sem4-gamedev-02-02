using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour
{
    public float ms_norm = 0.15f;
    public float ms_sprint = 0.2f;
    float ms = 0.15f;

    Vector3 rot = Vector3.zero;
    float rotSpeed = 40f;
    Animator anim;
    Transform trans;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        gameObject.transform.eulerAngles = rot;
    }

    // Update is called once per frame
    void Update()
    {
        CheckKey();
        gameObject.transform.eulerAngles = rot;
    }

    void CheckKey()
    {
        if (Input.GetKey(KeyCode.P)) {
            Vector3 pos; Quaternion q;
            trans.GetPositionAndRotation(out pos, out q);
            Debug.Log("pos / q: " + pos.ToString() + " / " + q.ToString());
        }

        /*
         * movement
         */

        if (Input.GetKey(KeyCode.LeftShift)) {
            ms = ms_sprint;
            /* anim.SetBool("Roll_Anim", true); */
        } else {
            ms = ms_norm;
            /* anim.SetBool("Roll_Anim", false); */
        }

        if (Input.GetKey(KeyCode.W)) {
            anim.SetBool("Walk_Anim", true);
            rot[1] = 0.0f;
            trans.Translate(trans.forward * ms, Space.World);
        }

        else if (Input.GetKey(KeyCode.S)) {
            anim.SetBool("Walk_Anim", true);
            rot[1] = 180.0f;
            trans.Translate(trans.forward * ms, Space.World);
        }

        else if (Input.GetKey(KeyCode.A)) {
            anim.SetBool("Walk_Anim", true);
            rot[1] = 270.0f;
            trans.Translate(trans.forward * ms, Space.World);
        }

        else if (Input.GetKey(KeyCode.D)) {
            anim.SetBool("Walk_Anim", true);
            rot[1] = 90.0f;
            trans.Translate(trans.forward * ms, Space.World);
        }

        else {
            anim.SetBool("Walk_Anim", false);
        }

        // Roll
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /* if (anim.GetBool("Roll_Anim")) */
            /* { */
            /*     anim.SetBool("Roll_Anim", false); */
            /* } */
            /* else */
            /* { */
            /*     anim.SetBool("Roll_Anim", true); */
            /* } */
        }

        // Close
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!anim.GetBool("Open_Anim"))
            {
                anim.SetBool("Open_Anim", true);
            }
            else
            {
                anim.SetBool("Open_Anim", false);
            }
        }
    }

}
