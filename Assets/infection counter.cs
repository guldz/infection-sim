using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class infectioncounter : MonoBehaviour
{
    public TMP_Text HealthyText;
    public TMP_Text InfectedText;
    public TMP_Text DeadText;
    public TMP_Text ImmuneText;

    private int healthy = 0;
    private int infected = 0;
    private int dead = 0;
    private int immune = 0;

    List<Maniska> maniskaList = new List<Maniska>();

    private float updateTimer = 0f;
    public float updateInterval = 0.5f; //updatat varje 0,5 sek
    void Start()
    {
        maniskaList.AddRange(FindObjectsOfType<Maniska>());
    }


    void Update()
    {



    }

}