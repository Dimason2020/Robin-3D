using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Parametrs/Bot Data")]
public class BaseBotData : MainCharacterData
{
    [Header("Очки урона")]
    public int damagePoint;

    [Header("Дистанция реагирования")]
    public float triggerDistance;

    [Header("Время передышки в секундах")]
    public float cooldownTime;
}
