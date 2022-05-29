using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using System;

public class MapGenerator : Singleton<MapGenerator>
{
    public bool IsMaxRoomCountReached { get => roomCount >= maxRoomCount; }
    public float SpawnCooldown { get => spawnCooldown; }
    [SerializeField] private float spawnCooldown;

    [SerializeField] private int maxRoomCount;
    private int roomCount = 1;

    private NavMeshBaker navMeshBaker;

    public Room RandomRoom
    {
        get
        {
            int roomIndex = UnityEngine.Random.Range(0, roomPrefabs.Length) ;
            return roomPrefabs[roomIndex];
        }
    }
    [SerializeField] private Room[] roomPrefabs;
    [SerializeField] private Room startRoom;

    public Corridor corridor;

    public Action OnMaxRoomCountReached;

    private IEnumerator Start()
    {
        navMeshBaker = GetComponent<NavMeshBaker>();

        yield return new WaitForSeconds(SpawnCooldown);

        startRoom.StartCoroutine(startRoom.SetRandomDirection());
    }

    public void IncreaseRoomCount()
    {
        roomCount++;

        if(roomCount >= maxRoomCount)
        {
            OnMaxRoomCountReached?.Invoke();
            navMeshBaker.Bake();
            Debug.Log("Bake");
        }
    }

    public void AddSurfaceToBaker(NavMeshSurface surface)
    {
        navMeshBaker.AddSurfaceToList(surface);
    }
}
