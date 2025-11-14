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

    

    List<Maniska> maniskaList = new List<Maniska>();

    private float updateTimer = 0f;
    public float updateInterval = 0.5f; //updatat varje 0,5 sek
    void Start()
    {
        

    //rekommenderade fix koder funkar inte wtf????
}


    void Update()
    {
        Maniska[] allHumans = FindObjectsOfType<Maniska>();

        int healthy = 0;
        int infected = 0;
        int dead = 0;
        int immune = 0;

        foreach (var m in allHumans)
        {
            switch (m.state)
            {
                case Maniska.HealthState.Healthy: healthy++; break; //syntax error when just case Maniska.HealthState.Healthy; break; type ++; perhaps? 
                case Maniska.HealthState.Infected: infected++; break;
                case Maniska.HealthState.Immune: immune++; break;
                case Maniska.HealthState.Dead: dead++; break;
            }

        }
        HealthyText.text = $"Healthy: {healthy}";  //om vill göra någon coolt effect för bara massor av nummer som gå fort använda "Insert"Text.text = insert.ToString(); 
        InfectedText.text = $"Infected: {infected}";
        ImmuneText.text = $"Immune: {immune}";
        DeadText.text = $"Dead: {dead}";
    }

}