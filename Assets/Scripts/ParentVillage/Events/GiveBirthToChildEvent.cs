﻿using UnityEngine;

public class GiveBirthToChildEvent : EventScript
{
    public override string Description
    {
        get
        {
            if (ChildManager.ChildCount <= 5)
            {
                return "You've had a baby.";
            }

            return "You have become pregnant, do you wish to keep the child?";
        }
    }

    public override string YesButtonText { get { return ChildManager.ChildCount <= 5 ? "OK" : "Yes"; } }
    public override bool NoButtonEnabled { get { return ChildManager.ChildCount <= 5 ? false : true; } }

    protected override void OnYes()
    {
        ChildManager.AddChild();

        if (ChildManager.ChildCount > ChildManager.MaxChildCount)
        {
            // If this child brings us over the max, we queue an event about the child leaving home
            GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>().QueueEvent(new ChildLeftHomeEventScript());
        }
    }
}