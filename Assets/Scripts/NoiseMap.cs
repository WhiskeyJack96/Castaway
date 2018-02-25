using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMap : MonoBehaviour {
    public float o1 = .5f;
    public float o2 = .25f;
    public float o3 = .25f;
    public float o4 = .1f;
    public float o5 = 1f;
    public int power = 3;
    private float seed1;
    private int seed2;
    private float listy= 100;
    private float listx = 100;
    List<float> locations;


	// Use this for initialization
	void Start () {
        locations = new List<float>();
        seed1 =Random.Range(1,10000);
        seed2 =Random.Range(1,10000);

		for(int i = 0; i <listx; i++)
        {
            for(int j = 0; j <listy; j++)
            {
                float heightpoint = (o5*Mathf.PerlinNoise(seed1 + (i/listx - .5f),seed1 + (j/listy - .5f))+
                                o1*Mathf.PerlinNoise(seed1 + (2*i/listx - .5f),seed1 + (2*j/listy - .5f))+
                                o2*Mathf.PerlinNoise(seed1 + (4*i/listx - .5f),seed1 + (4*j/listy - .5f))+
                                o3*Mathf.PerlinNoise(seed1 + (8*i/listx - .5f),seed1 + (8*j/listy - .5f))+
                                o4*Mathf.PerlinNoise(seed1 + (16*i/listx - .5f),seed1 + (16*j/listy - .5f))
                    );

                heightpoint /= 2f;
                //noisepoint =Mathf.Pow(noisepoint, power);
                //locations.Add(heightpoint);

                float waterpoint = (o5*Mathf.PerlinNoise(seed2 + (i/listx - .5f),seed2 + (j/listy - .5f))+
                                o1*Mathf.PerlinNoise(seed2 + (2*i/listx - .5f),seed2 + (2*j/listy - .5f))+
                                o2*Mathf.PerlinNoise(seed2 + (4*i/listx - .5f),seed2 + (4*j/listy - .5f))+
                                o3*Mathf.PerlinNoise(seed2 + (8*i/listx - .5f),seed2 + (8*j/listy - .5f))+
                                o4*Mathf.PerlinNoise(seed2 + (16*i/listx - .5f),seed2 + (16*j/listy - .5f))
                    );

                waterpoint /= 2f;

                
                //noisepoint =Mathf.Pow(noisepoint, power);
                //locations.Add(noisepoint);
            }
        }
        locations.Sort();
        print(locations[100*100-1]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
