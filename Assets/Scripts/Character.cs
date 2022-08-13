using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Character : MonoBehaviour {
    public Ability Attack;
    private CancellationTokenSource _currentComboCoroutine;

    private async void Start() {
        while (true) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                _currentComboCoroutine?.Cancel();
                _currentComboCoroutine = new CancellationTokenSource();
                await Attack.Logic.Execute();
                _ = ComboSystem.Run(Attack, _currentComboCoroutine.Token);
            }

            await UniTask.DelayFrame(1);
        }
    }
}
