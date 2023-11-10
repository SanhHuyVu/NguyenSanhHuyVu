
using UnityEngine;

[System.Serializable]
public class BlockData
{
    [SerializeField] private int value;
    [SerializeField] private Color color;
    [SerializeField] private int scoreGain;
    public int Value => value;
    public Color Color => color;
    public int ScoreGain => scoreGain;
}
