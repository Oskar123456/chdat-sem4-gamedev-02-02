using UnityEngine;

public class MainCam : MonoBehaviour
{
    GameObject player;
    Transform player_pos;
    Quaternion cam_rot = Quaternion.Euler(new Vector3(45, 0, 0));

    void Awake()
    {
        player = GameObject.Find("robotSphere");
        player_pos = player.transform;
    }

    void Start()
    {
        transform.SetPositionAndRotation(GetCamPos(), cam_rot);
    }

    void Update()
    {
        transform.SetPositionAndRotation(GetCamPos(), cam_rot);
    }

    Vector3 GetCamPos()
    {
        return new Vector3(player_pos.position.x, player_pos.position.y + 50, player_pos.position.z - 50);
    }
}
