﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TakeFamilyToChurchEventScript : RandomEventScript
{
    public override string Description
    {
        get
        {
            return "You take your family to church.";
        }
    }

    public override float EducationYes { get { return 0; } }
    public override float IncomeYes { get { return 0; } }
    public override float HealthYes { get { return 0; } }
    public override float SafetyYes { get { return 0; } }
    public override float HappinessYes { get { return 0; } }

    public override float EducationNo { get { return 0; } }
    public override float IncomeNo { get { return 0; } }
    public override float SafetyNo { get { return 0; } }
    public override float HealthNo { get { return 0; } }
    public override float HappinessNo { get { return 0; } }
}