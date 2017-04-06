﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class UpgradeHouseEventScript : EventScript
{
    public override string Description
    {
        get
        {
            return "Do you wish to upgrade your house? ( CFA " + IncomeYes.ToString() + " )";
        }
    }

    // Different upgrades for your house in unlockable tiers - electricity, well, toilet
    // Child health deteriorates every year based on current health
    // These upgrades provide a passive health bonus (and maybe safety) every year and will eventually negate deterioration and even surpass it

    // House upgrade = $75?

    public override float EducationYes { get { return 10; } }
    public override float IncomeYes { get { return 46125; } }
    public override float HealthYes { get { return -15; } }
    public override float SafetyYes { get { return -50; } }
    public override float HappinessYes { get { return -25; } }

    public override float EducationNo { get { return 0; } }
    public override float IncomeNo { get { return -20; } }
    public override float SafetyNo { get { return 30; } }
    public override float HealthNo { get { return 35; } }
    public override float HappinessNo { get { return 15; } }
}