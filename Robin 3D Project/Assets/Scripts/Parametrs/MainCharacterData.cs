using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Parametrs/Main Data")]
public class MainCharacterData : ScriptableObject
{
    [Header("��������")]
    public int movementSpeed;
    [Header("���� ��������")]
    public int healthPoint;
}
