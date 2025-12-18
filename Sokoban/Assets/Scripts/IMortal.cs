using System;
using UnityEngine.Events;

public interface IMortal
{
    public Action OnDeath { get; set; }

    public void Death();
}