using Sirenix.OdinInspector;
using UnityEngine;

[HideLabel]
[InlineProperty]
[PropertySpace(5, 5)]
[Title("@$property.NiceName", Subtitle = "@$property.ValueEntry.WeakSmartValue.GetType().ToString()", TitleAlignment = TitleAlignments.Split)]
public abstract class ValueReference<TCon, TRef> where TRef : ValueAsset<TCon>
{
    [HideLabel] 
    [SerializeField]
    [ValueDropdown("valueOptions")]
    [HorizontalGroup("base", 100)]
    [VerticalGroup("base/VerticalLeft")]
    protected bool useConstantValue = default;

    [HideLabel] 
    [SerializeField]
    [PropertySpace(3)]
    [HideIf("useConstantValue")] 
    [ValueDropdown("editOptions")]
    [VerticalGroup("base/VerticalLeft")]
    [ShowIf("@assetReference != null && useConstantValue == false")]
    protected bool editAsset = default;
    
    [HideLabel]
    [SerializeField]
    [ShowIf("useConstantValue")]
    [VerticalGroup("base/VerticalRight")]
    protected TCon constantValue = default;
    
    [HideLabel]
    [SerializeField]
    [HideIf("useConstantValue")] 
    [VerticalGroup("base/VerticalRight")]
    [OnValueChanged(nameof(UpdateReference))]
    protected TRef assetReference = default;
    
    [HideLabel]
    [SerializeField]
    [PropertySpace(3)]
    [EnableIf("editAsset")]
    [VerticalGroup("base/VerticalRight")]
    [InlineEditor(InlineEditorObjectFieldModes.Hidden)]
    [ShowIf("@assetReference != null && useConstantValue == false")]
    protected TRef inlineReference = default;

    public TCon Value
    {
        get => useConstantValue ? constantValue : assetReference.value;
        set => assetReference.value = value;
    }
    
    private void UpdateReference() => inlineReference = assetReference;
    private ValueDropdownList<bool> valueOptions = new ValueDropdownList<bool> {{"Constant", true}, {"Reference", false}};
    private ValueDropdownList<bool> editOptions = new ValueDropdownList<bool> {{"Locked", false}, {"Editable", true}};
}