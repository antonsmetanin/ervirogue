using System;
using UnityEngine;

[CreateAssetMenu]
public class Ability : ScriptableObject {
    [Serializable]
    public struct Combo {
        public KeyCode InputAction;
        public int TimeMs;
        public Ability NextAbility;
    }

    public AbilityLogic Logic;
    public Combo[] Combos;
}
