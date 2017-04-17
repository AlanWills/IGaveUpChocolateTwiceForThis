﻿using System;
using UnityEngine;

public class SendChildToWorkEventScript : InteractableBuildingEventScript
{
    public override string Name
    {
        get { return "Farm"; }
    }

    protected override string BuildingDescription
    {
        get { return "The fields stretch for miles under the burning sun."; }
    }

    protected override string ChildSelectedDescription
    {
        get
        {
            return "Do you wish to send " + ChildManager.SelectedChild.Name + " to work to earn money for the family.";
        }
    }

    // Child gets money at the end, but also always happiness cost, always health cost and slim chance of trafficking
    // Child earns $190 per year
    // 5% are actually paid - see how this fits with the game
    // Child locked in for a year

    private const float Salary = 116850;

    // Every 20 times, the player is guaranteed a pay out
    private static int numberOfTimesSent = 0;
    private static bool childPaid = false;

    protected override bool YesButtonEnabledImpl { get { return true; } }
    protected override string NoButtonTextImpl { get { return "No"; } }
    public override float CostToPerform { get { return 0; } }
    protected override float LockTime { get { return TimeManager.SecondsPerYear; } }
    protected override string OnShowAudioClipPath { get { return "Audio/Work"; } }

    public override BuildingType BuildingType { get { return BuildingType.Work; } }
    protected override Vector3 BuildingLocation { get { return GameObject.Find("Farm").transform.position; } }

    public override string GetOnCompleteDescription(Child child)
    {
        if (childPaid)
        {
            return child.Name + " completes a hard year at the cocoa farm and is paid CFA " + ((int)(Salary * (1 + (child.Education * 0.01f)))).ToString() + ".";
        }
        return child.Name + " completes a hard year at the cocoa farm, but receives no money.  Not all children get paid.";
    }

    protected override DataPacket GetDataPacketPerSecond(Child child)
    {
        return new DataPacket(
            0, 
            -Math.Min(50, child.Health) / LockTime, 
            -Math.Min(50, child.Safety) / LockTime, 
            -Math.Min(50, child.Happiness) / LockTime);
    }

    protected override void OnTimeComplete(Child child)
    {
        base.OnTimeComplete(child);

        numberOfTimesSent++;

        System.Random random = new System.Random();
        childPaid = random.NextDouble() >= 0.95f;

        if (numberOfTimesSent == 20)
        {
            childPaid = true;
            numberOfTimesSent = 0;
        }

        if (childPaid)
        {
            IncomeManager.AddMoney((int)(Salary * (1 + (child.Education * 0.01f))));
        }
    }
}