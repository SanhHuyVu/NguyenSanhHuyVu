using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum DriveMode { Manual, Automatic }
    [SerializeField] private float speed = 50;
    [SerializeField] private List<Transform> destinations;
    [SerializeField] private int curDes = 0;

    private DriveMode mode = DriveMode.Manual;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (mode == DriveMode.Automatic) mode = DriveMode.Manual;
            else mode = DriveMode.Automatic;
        }

        switch (mode)
        {
            case DriveMode.Manual:
                ManualDrive();
                break;
            case DriveMode.Automatic:
                AutoDrive();
                break;
        }


    }

    void AutoDrive()
    {
        if (curDes >= destinations.Count) curDes = 0;
        else
        {
            transform.Translate((destinations[curDes].transform.position - transform.position).normalized * speed * Time.deltaTime);

            if ((destinations[curDes].transform.position - transform.position).magnitude < 0.1f) curDes++;
        }
    }

    void ManualDrive()
    {
        Vector3 curPos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((new Vector3(curPos.x, curPos.y, curPos.z + 1) - curPos).normalized * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((new Vector3(curPos.x, curPos.y, curPos.z - 1) - curPos).normalized * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((new Vector3(curPos.x - 1, curPos.y, curPos.z) - curPos).normalized * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((new Vector3(curPos.x + 1, curPos.y, curPos.z) - curPos).normalized * speed * Time.deltaTime);
        }
    }
}
