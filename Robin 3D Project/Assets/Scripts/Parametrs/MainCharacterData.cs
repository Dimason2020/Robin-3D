using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Parametrs/Main Data")]
public class MainCharacterData : ScriptableObject
{
    [Header("���� ��������")]
    public int healthPoint;
    [Header("��������")]
    public int movementSpeed;
}
