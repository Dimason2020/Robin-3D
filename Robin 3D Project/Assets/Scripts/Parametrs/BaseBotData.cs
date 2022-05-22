using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Parametrs/Bot Data")]
public class BaseBotData : MainCharacterData
{
    [Header("Количество брони")]
    public int armorPoint;

    [Header("Скорость движения при раше")]
    public float rushSpeed;

    [Header("Очки урона")]
    public int damagePoint;

    [Header("Дистанция реагирования")]
    public float triggerDistance;

    [Header("Дистанция атаки")]
    public float attackDistance;

    [Header("Дистанция раш атаки")]
    public float rushStartDistance;

    [Header("Время передышки в секундах")]
    public float cooldownTime;
}
