using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] bool oneTimeUse = false;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            PlayerController player = other.transform.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(damage);

            if (oneTimeUse) transform.gameObject.SetActive(false);
        }
    }
}
