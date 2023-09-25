using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    [SerializeField] private List<Transform> destinations;
    [SerializeField] private float speed;
    [SerializeField] private int currentDes = 0;

    // Update is called once per frame
    void Update()
    {
        if (currentDes >= destinations.Count) currentDes = 0;
        if (currentDes < destinations.Count)
        {
            transform.Translate((destinations[currentDes].position - transform.position).normalized * speed * Time.deltaTime);

            if ((destinations[currentDes].position - transform.position).magnitude <= 0.1f)
            {
                currentDes++;
            }
        }
    }
}
