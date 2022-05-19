using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Parametrs/Main Data")]
public class MainCharacterData : ScriptableObject
{
    [Header("Очки здоровья")]
    public int healthPoint;
    [Header("Скорость")]
    public int movementSpeed;
}
