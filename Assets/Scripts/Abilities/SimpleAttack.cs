using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu]
public class SimpleAttack : AbilityLogic
{
    public async override UniTask Execute() {
        Debug.Log($"Executing simple attack");
        await UniTask.Delay(TimeSpan.FromMilliseconds(500));
        Debug.Log($"Finished executing simple attack");
    }
}
