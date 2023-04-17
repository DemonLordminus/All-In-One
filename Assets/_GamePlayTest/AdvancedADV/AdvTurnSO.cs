using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Turn", menuName = "AdvancedAdv/Turn", order = 1)]
public class AdvTurnSO : ScriptableObject
{
    public List<AdvElement> requiredElements;
    public string nextTurnInfo;


}