using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 50;
    [SerializeField] private List<Transform> destinations;
    [SerializeField] private int curDes = 0;


    // Update is called once per frame
    void Update()
    {
        if (curDes >= destinations.Count) curDes = 0;
        else
        {
            transform.Translate((destinations[curDes].transform.position - transform.position).normalized * speed * Time.deltaTime);

            if ((destinations[curDes].transform.position - transform.position).magnitude < 0.1f) curDes++;
        }
    }
}
