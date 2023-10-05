using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAutoDrive : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [SerializeField] private float rotateSpeed = 15;
    [SerializeField] private List<Transform> destinations;
    [SerializeField] private int curDes = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AutoDrive();
    }

    void AutoDrive()
    {
        if (curDes >= destinations.Count) curDes = 0;
        else
        {
            Vector3 moveDir = destinations[curDes].transform.position - transform.position;

            Vector3 move = new Vector3(moveDir.x, 0, moveDir.z);

            if ((destinations[curDes].transform.position - transform.position).magnitude <= 0.5f) curDes++;

            rb.velocity = move.normalized * speed;
            if (move != Vector3.zero) transform.forward = Vector3.Slerp(transform.forward, move, rotateSpeed * Time.deltaTime);
        }
    }
}
