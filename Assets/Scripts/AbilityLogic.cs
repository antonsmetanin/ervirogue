using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class AbilityLogic : ScriptableObject {
    public abstract UniTask Execute();
}
