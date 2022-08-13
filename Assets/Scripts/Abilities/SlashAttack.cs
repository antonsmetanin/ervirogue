using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu]
public class SlashAttack : AbilityLogic
{
    public async override UniTask Execute() {
        Debug.Log($"Executing slash attack");
        await UniTask.Delay(TimeSpan.FromMilliseconds(500));
        Debug.Log($"Finished executing slash attack");
    }
}
