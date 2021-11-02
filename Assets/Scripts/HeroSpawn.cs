using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawn : MonoBehaviour
{
    [SerializeField] GameObject firstPositionGO; // First reference position.
    [SerializeField] GameObject squareSpot; // the cube gameobject.

    public Dictionary<string, Vector3> spotsMap = new Dictionary<string, Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        // init spreading...
        Spread(10, 10, 1, firstPositionGO.transform.position);
    }


    // Spreading every hero spot possible.
    private void Spread(int lines, int columns, float scale, Vector3 firstPosition)
    {
        for (int x = 0; x < lines; x++)
        {
            for (int z = 0; z < columns; z++)
            {
                var positions = new Vector3(x, 0, z) + firstPositionGO.transform.position;

                var spot = Instantiate(squareSpot, positions, firstPositionGO.transform.rotation, transform);

                spot.name = x.ToString() + z.ToString();

                spotsMap.Add(spot.name, spot.transform.position);
            }
        }
    }

    public Vector3 GetNearestSpot(Vector3 heroPos)
    {
        Vector3 nearestSpot = new Vector3(0, 0, 0);
        
        foreach (Vector3 spot in spotsMap.Values)
        {
            if (nearestSpot == new Vector3(0, 0, 0))
            {
                nearestSpot = spot;
            }
            
            if (Vector3.Distance(heroPos, spot) < Vector3.Distance(heroPos, nearestSpot))
            {
                nearestSpot = spot;
            }
        }

        return nearestSpot;
    }
}
