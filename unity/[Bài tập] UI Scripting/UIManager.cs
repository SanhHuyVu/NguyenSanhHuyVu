using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public event EventHandler OnGameRestart;
    public enum STATE { Playing, Paused }
    public static UIManager Instance { get; private set; }

    [SerializeField] private HUD hud;
    [SerializeField] private Transform pauseScreen;

    private STATE state;

    private void Awake()
    {
        Instance = this;
        state = STATE.Playing;
        pauseScreen.gameObject.SetActive(false);
    }

    public HUD GetHUD()
    {
        return hud;
    }

    public void TogglePauseGame()
    {
        if (state == STATE.Playing)
        {
            state = STATE.Paused;
            Time.timeScale = 0;
            pauseScreen.gameObject.SetActive(true);
        }
        else
        {
            state = STATE.Playing;
            Time.timeScale = 1;
            pauseScreen.gameObject.SetActive(false);
        }
    }

    public void Restart()
    {
        state = STATE.Playing;
        Time.timeScale = 1;
        pauseScreen.gameObject.SetActive(false);
        
        OnGameRestart?.Invoke(this, EventArgs.Empty);
    }
}
