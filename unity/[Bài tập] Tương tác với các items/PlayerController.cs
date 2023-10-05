using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum DriveMode { Manual, Automatic }
    [SerializeField] private float rotateSpeed = 15;
    [SerializeField] private float speed = 20;
    [SerializeField] private int curDes = 0;
    [SerializeField] private int damage = 0;
    [SerializeField] private float fuel = 100;
    [SerializeField] private List<Transform> destinations;

    private float currentSpeed;

    private Rigidbody rb;

    private DriveMode mode = DriveMode.Manual;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            curDes = GetClosestDes();

            if (mode == DriveMode.Automatic) mode = DriveMode.Manual;
            else mode = DriveMode.Automatic;
        }

        switch (mode)
        {
            case DriveMode.Manual:
                ManualDrive(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
                break;
            case DriveMode.Automatic:
                AutoDrive();
                break;
        }

        if (fuel > 0)
        {
            fuel -= Time.deltaTime;
            currentSpeed = speed;
        }
        else currentSpeed = speed - (speed * 0.35f);
    }

    void AutoDrive()
    {
        if (curDes >= destinations.Count) curDes = 0;
        else
        {
            Vector3 moveDir = destinations[curDes].transform.position - transform.position;

            Vector3 move = new Vector3(moveDir.x, 0, moveDir.z);

            if ((destinations[curDes].transform.position - transform.position).magnitude <= 0.5f) curDes++;

            ManualDrive(move);
        }
    }

    int GetClosestDes()
    {
        float closestDis = Vector3.Distance(destinations[curDes].position, transform.position);
        for (int i = 0; i < destinations.Count; i++)
        {
            if (Vector3.Distance(destinations[i].position, transform.position) < closestDis)
            {
                curDes = i;
                return i;
            }
        }
        return 0;
    }

    void ManualDrive(Vector3 move)
    {
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = move.normalized * currentSpeed;
        if (move != Vector3.zero) transform.forward = Vector3.Slerp(transform.forward, move, rotateSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        this.damage += damage;
    }
    public void AddFuel(float fuel)
    {
        this.fuel += fuel;
    }
}
