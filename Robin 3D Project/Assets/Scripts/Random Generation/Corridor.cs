using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour
{
    [SerializeField] private Transform anchorPoint;
    [SerializeField] private Transform spawnPoint;

    private MapGenerator mapGenerator;

    public IEnumerator SetOffset(Direction direction, MapGenerator _mapGenerator)
    {
        mapGenerator = _mapGenerator;

        float distance = Vector3.Distance(transform.position,
            anchorPoint.position);

        switch (direction)
        {
            case Direction.Forward:

                transform.localPosition = new Vector3(transform.localPosition.x,
                transform.localPosition.y,
                transform.localPosition.z + distance);

                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;

            case Direction.Back:

                transform.localPosition = new Vector3(transform.localPosition.x,
                transform.localPosition.y,
                transform.localPosition.z - distance);

                transform.rotation = Quaternion.Euler(0, -90, 0);
                break;

            case Direction.Right:

                transform.localPosition = new Vector3(transform.localPosition.x + distance,
                transform.localPosition.y,
                transform.localPosition.z);

                transform.rotation = Quaternion.Euler(0, 180, 0); 
                break;

            case Direction.Left:

                transform.localPosition = new Vector3(transform.localPosition.x - distance,
                transform.localPosition.y,
                transform.localPosition.z);

                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }

        yield return new WaitForSeconds(mapGenerator.SpawnCooldown);

        CreateRoom(direction);
    }

    private void CreateRoom(Direction direction)
    {
        if (!mapGenerator.IsMaxRoomCountReached)
        {
            Room room = Instantiate(mapGenerator.RandomRoom,
            spawnPoint.position,
            Quaternion.identity);

            room.transform.SetParent(mapGenerator.transform);
            room.SetOffset(direction);

            mapGenerator.IncreaseRoomCount();
        }
        
    }
}
