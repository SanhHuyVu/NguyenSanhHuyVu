using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSingle : MonoBehaviour
{
    TrackCheckPoints trackCheckPoints;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trackCheckPoints.GoThroughCheckPoint(this);
        }
    }

    public void SetTrackCheckPoints(TrackCheckPoints trackCheckPoints)
    {
        this.trackCheckPoints = trackCheckPoints;
    }
}
