using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum DriveMode { Manual, Automatic }
    [SerializeField] private HUD hud;
    [SerializeField] private float rotateSpeed = 15;
    [SerializeField] private float speed = 20;
    [SerializeField] private List<Transform> destinations;
    private int curDes = 0;
    private int hp = 1000;
    private float fuel = 100;

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
            fuel -= 2 * Time.deltaTime;
            fuel = Mathf.Clamp(fuel, 0, 100);
            hud.UpdateFuel(fuel);
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
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, 1000);
        hud.UpdateHealth(hp);
    }
    public void AddFuel(float fuel)
    {
        this.fuel += fuel;
        fuel = Mathf.Clamp(fuel, 0, 100);
        hud.UpdateFuel(fuel);
    }
}
