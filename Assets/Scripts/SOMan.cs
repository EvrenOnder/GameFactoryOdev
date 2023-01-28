using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Man Attribute")]
public class SOMan : ScriptableObject
{
    public float distanceBetween;
    public float defYPos;

    public float forceForCentre;

    public ForceMode forceMode;

    public float navTime= 0.5F;

    public float reOrganizeTime= 0.75F;
}
