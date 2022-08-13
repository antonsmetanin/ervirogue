using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public static class ComboSystem {
    public static async UniTask Run(Ability ability, CancellationToken cancellationToken) {
        while (true) {
            if (ability.Combos.Length == 0) {
                return;
            }

            ability = await WaitForCombo(ability.Combos, cancellationToken);

            if (ability == null) {
                return;
            }

            await ability.Logic.Execute();
            cancellationToken.ThrowIfCancellationRequested();
        }
    }

    private static async UniTask<Ability> WaitForCombo(Ability.Combo[] combos, CancellationToken cancellationToken) {
        var startTime = Time.time;

        while (true) {
            var elapsedTime = TimeSpan.FromSeconds(Time.time - startTime);
            var comboCheckResult = CheckCombos(combos, elapsedTime);

            if (comboCheckResult.NextAbility != null) {
                return comboCheckResult.NextAbility;
            }

            if (!comboCheckResult.HasAvailableCombos) {
                return null;
            }
            
            await UniTask.DelayFrame(1, cancellationToken: cancellationToken);
        }
    }

    private struct ComboCheckResult {
        public bool HasAvailableCombos;
        public Ability NextAbility;
    }

    private static ComboCheckResult CheckCombos(Ability.Combo[] combos, TimeSpan elapsedTime) {
        var hasAvailableCombos = false;

        foreach (var combo in combos) {
            if (elapsedTime > TimeSpan.FromMilliseconds(combo.TimeMs)) {
                continue;
            }

            hasAvailableCombos = true;

            if (Input.GetKeyDown(combo.InputAction)) {
                return new ComboCheckResult { NextAbility = combo.NextAbility };
            }
        }

        return new ComboCheckResult { HasAvailableCombos = hasAvailableCombos };
    }
}