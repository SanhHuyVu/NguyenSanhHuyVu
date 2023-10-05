using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField] int ammount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.transform.gameObject.GetComponent<PlayerController>();
            player.AddFuel(ammount);
            transform.gameObject.SetActive(false);
        }
    }
}
