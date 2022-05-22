using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Parametrs/Bot Data")]
public class BaseBotData : MainCharacterData
{
    [Header("���������� �����")]
    public int armorPoint;

    [Header("�������� �������� ��� ����")]
    public float rushSpeed;

    [Header("���� �����")]
    public int damagePoint;

    [Header("��������� ������������")]
    public float triggerDistance;

    [Header("��������� �����")]
    public float attackDistance;

    [Header("��������� ��� �����")]
    public float rushStartDistance;

    [Header("����� ��������� � ��������")]
    public float cooldownTime;
}
