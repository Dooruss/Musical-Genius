using TMPro;
using UnityEngine;

public class CharacterStatsUI : MonoBehaviour
{
    public TMP_Text pointsText;
    public TMP_Text performanceText;
    public TMP_Text writingText;
    public TMP_Text vocalsText;
    public TMP_Text producingText;
    public int availablePoints = 50;
    public int livePerformance = 0;
    public int songWriting = 0;
    public int producing = 0;
    public int vocals = 0;

    private SaveData data;

    void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        pointsText.text = "Available Points: " + availablePoints;
        performanceText.text = "Live Performance : " + livePerformance;
        writingText.text = "Song Writing : " + songWriting;
        vocalsText.text = "Vocals : " + vocals;
        producingText.text = "Producing : " + producing;
    }
    public void AddLivePerformance()
    {
        if (availablePoints <= 0) return;

        livePerformance++;
        availablePoints--;
        RefreshUI();
    }

    public void RemoveLivePerformance()
    {
        if (livePerformance <= 0) return;
        livePerformance--;
        availablePoints++;
        RefreshUI();
    }

    public void AddSongWriting()
    {
        if (availablePoints <= 0) return;
        songWriting++;
        availablePoints--;
        RefreshUI();
    }

    public void RemoveSongWriting()
    {
        if (songWriting <= 0) return;
        songWriting--;
        availablePoints++;
        RefreshUI();
    }

    public void AddVocals()
    {
        if (availablePoints <= 0) return;
        vocals++;
        availablePoints--;
        RefreshUI();
    }

    public void RemoveVocals()
    {
        if (vocals <= 0) return;
        vocals--;
        availablePoints++;
        RefreshUI();
    }

    public void AddProducing()
    {
        if (availablePoints <= 0) return;
        producing++;
        availablePoints--;
        RefreshUI();
    }

    public void RemoveProducing()
    {
        if (producing <= 0) return;
        producing--;
        availablePoints++;
        RefreshUI();
    }
}