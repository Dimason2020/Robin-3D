using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Parametrs/Bot Data")]
public class BaseBotData : MainCharacterData
{
    [Header("���� �����")]
    public int damagePoint;

    [Header("��������� ������������")]
    public float triggerDistance;

    [Header("����� ��������� � ��������")]
    public float cooldownTime;
}
