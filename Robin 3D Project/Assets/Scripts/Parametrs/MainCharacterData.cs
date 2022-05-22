using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Parametrs/Main Data")]
public class MainCharacterData : ScriptableObject
{
    [Header("Скорость")]
    public int movementSpeed;
    [Header("Очки здоровья")]
    public int healthPoint;
}
