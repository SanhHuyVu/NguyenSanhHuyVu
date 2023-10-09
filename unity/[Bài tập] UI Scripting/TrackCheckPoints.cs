using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckPoints : MonoBehaviour
{
    [SerializeField] private HUD hud;
    List<CheckPointSingle> checkPointSingleList;
    int nextCheckpointSingleIndex;
    [SerializeField] private int laps;

    // Start is called before the first frame update
    void Awake()
    {
        checkPointSingleList = new List<CheckPointSingle>();
        Transform checkPointsTranform = transform.Find("CheckPoints");

        nextCheckpointSingleIndex = 0;
        laps = 0;

        foreach (Transform checkPointSingleTranform in checkPointsTranform)
        {
            CheckPointSingle checkPointSingle = checkPointSingleTranform.gameObject.GetComponent<CheckPointSingle>();

            checkPointSingleList.Add(checkPointSingle);

            if (checkPointSingleList.IndexOf(checkPointSingle) != nextCheckpointSingleIndex)
            {
                checkPointSingleTranform.gameObject.SetActive(false);
            }

            checkPointSingle.SetTrackCheckPoints(this);
        }
    }

    private void Start()
    {
        UIManager.Instance.OnGameRestart += OnGameRestart;
    }

    public void GoThroughCheckPoint(CheckPointSingle checkPointSingle)
    {
        int currentCheckpoitn = checkPointSingleList.IndexOf(checkPointSingle);
        if (currentCheckpoitn == nextCheckpointSingleIndex)
        {
            if (nextCheckpointSingleIndex >= checkPointSingleList.Count - 1)
            {
                nextCheckpointSingleIndex = 0;
                laps++;
                hud.UpdateLaps(laps);
            }
            else nextCheckpointSingleIndex++;

            checkPointSingleList[currentCheckpoitn].gameObject.SetActive(false);
            checkPointSingleList[nextCheckpointSingleIndex].gameObject.SetActive(true);

            Debug.Log("CORRECT");
        }
        else Debug.Log("WRONG"); ;
    }

    private void OnGameRestart(object sender, EventArgs e)
    {
        laps = 0;
        nextCheckpointSingleIndex = 0;
        foreach (CheckPointSingle checkPointSingle in checkPointSingleList)
        {
            if (checkPointSingleList.IndexOf(checkPointSingle) != nextCheckpointSingleIndex) checkPointSingle.gameObject.SetActive(false);
            else checkPointSingle.gameObject.SetActive(true);
        }
    }
}
