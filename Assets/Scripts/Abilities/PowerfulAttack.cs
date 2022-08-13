using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu]
public class PowerfulAttack : AbilityLogic
{
    public async override UniTask Execute() {
        Debug.Log($"Executing powerful attack");
        await UniTask.Delay(TimeSpan.FromMilliseconds(500));
        Debug.Log($"Finished executing powerful attack");
    }
}
