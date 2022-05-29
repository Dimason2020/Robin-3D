using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    [SerializeField] private List<NavMeshSurface> surfaces = new List<NavMeshSurface>();

    public void AddSurfaceToList(NavMeshSurface surface)
    {
        //surfaces.Add(surface);
    }

    public void Bake()
    {
        for (int i = 0; i < surfaces.Count; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }
}
