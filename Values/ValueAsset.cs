using Sirenix.OdinInspector;
using UnityEngine;

[HideMonoScript]
public abstract class ValueAsset<TCon> : ScriptableObject
{
    [HideLabel]
    public TCon value;
}