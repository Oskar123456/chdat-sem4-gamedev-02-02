using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour
{
    public float jump_force = 1000.0f;
    float ms_norm = 0.1f;
    float ms_sprint = 0.2f;
    float ms = 0.1f;

    Vector3 rot = Vector3.zero;
    float rotSpeed = 40f;
    bool in_air = false;
    Animator anim;
    Transform trans;
    Rigidbody rb;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
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

        anim.SetBool("Walk_Anim", false);

        if (Input.GetKey(KeyCode.W)) {
            anim.SetBool("Walk_Anim", true);
            rot[1] = 0.0f;
            trans.Translate(trans.forward * ms, Space.World);
        }

        if (Input.GetKey(KeyCode.S)) {
            anim.SetBool("Walk_Anim", true);
            rot[1] = 180.0f;
            trans.Translate(trans.forward * ms, Space.World);
        }

        if (Input.GetKey(KeyCode.A)) {
            anim.SetBool("Walk_Anim", true);
            rot[1] = 270.0f;
            trans.Translate(trans.forward * ms, Space.World);
        }

        if (Input.GetKey(KeyCode.D)) {
            anim.SetBool("Walk_Anim", true);
            rot[1] = 90.0f;
            trans.Translate(trans.forward * ms, Space.World);
        }

        if (!in_air && Input.GetKeyDown(KeyCode.Space)) {
            in_air = true;
            rb.AddForce(trans.up * jump_force, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            if (!anim.GetBool("Open_Anim")) {
                anim.SetBool("Open_Anim", true);
            }
            else {
                anim.SetBool("Open_Anim", false);
            }
        }
    }

    void OnCollisionEnter()
    {
        in_air = false;
        /* Debug.Log("in_air: " + in_air.ToString()); */
    }

}
