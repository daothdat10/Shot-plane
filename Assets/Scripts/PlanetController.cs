using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets;
    Queue<GameObject> availablePlanets = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        availablePlanets.Enqueue(Planets[0]);
        availablePlanets.Enqueue(Planets[1]);
        availablePlanets.Enqueue(Planets[2]);

        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MovePlanetDown()
    {
        EnqueuePlanets();

        if(availablePlanets.Count == 0)
        {
            return;
        }
        GameObject aPlanet = availablePlanets.Dequeue();
        aPlanet.GetComponent<Planet>().isMoving = true;
    }
    void EnqueuePlanets()
    {
        foreach(GameObject aplanet in Planets) {
            
            if((aplanet.transform.position.y<0)&&(!aplanet.GetComponent<Planet>().isMoving))
            {
                aplanet.GetComponent<Planet>().ResePosition();
                availablePlanets.Enqueue(aplanet);
            }
        }
    }
}
