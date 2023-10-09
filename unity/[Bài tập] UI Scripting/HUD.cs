using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI laps;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI fuel;

    // Start is called before the first frame update
    void Start()
    {
        laps.text = "0";
        health.text = "1000/1000";
        fuel.text = "100/100>";
    }

    public void UpdateLaps(int laps)
    {
        this.laps.text = "" + laps;
    }
    public void UpdateHealth(int hp)
    {
        this.health.text = hp + "/1000";
    }
    public void UpdateFuel(float fuel)
    {
        this.fuel.text = fuel.ToString("F0") + "/100";
    }
}
