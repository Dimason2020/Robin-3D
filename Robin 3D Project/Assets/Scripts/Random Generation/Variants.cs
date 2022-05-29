using System.Collections.Generic;
using UnityEngine;

public class Variants : MonoBehaviour
{
    [SerializeField] private List<GameObject> groups;

    private void OnEnable()
    {
        MapGenerator.Instance.OnMaxRoomCountReached += () =>
        {
            RandomGroup();
        };
    }

    private void RandomGroup()
    {
        foreach (GameObject group in groups)
        {
            group.SetActive(false);
        }

        int randomIndex = Random.Range(0, groups.Count);
        Debug.Log("Random Group : " + randomIndex);

        groups[randomIndex].SetActive(true);
    }
}
