using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetSystem 
{
    event Action OnTargetAcquired;
    event Action OnTargetLost;

    GameObject CurrentTarget { get; }
}
