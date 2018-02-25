using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMap : MonoBehaviour {
    public float o1 = .5f;
    public float o2 = .25f;
    public float o3 = .25f;
    public float o4 = .1f;
    public float o5 = 1f;
    public float power = 1.1f;
    private float seed1;
    private List<GameObject> map;

    public GameObject grass;
    public GameObject sand;
    public GameObject mountain;
    public GameObject icy;
    public GameObject scarysand;

    private int seed2;
    private float listy= 50;
    private float listx = 50;
    List<int> locations;


	// Use this for initialization
	void Start () {
        map = new List<GameObject>();
        locations = new List<int>();
        seed1 =Random.Range(1,10000);
        seed2 =Random.Range(1,10000);

        //print(grass.GetComponent<Collider2D>().bounds);


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
                heightpoint =Mathf.Pow(heightpoint, power);
                //locations.Add(heightpoint);

                float waterpoint = (o5*Mathf.PerlinNoise(seed2 + (i/listx - .5f),seed2 + (j/listy - .5f))+
                                o1*Mathf.PerlinNoise(seed2 + (2*i/listx - .5f),seed2 + (2*j/listy - .5f))+
                                o2*Mathf.PerlinNoise(seed2 + (4*i/listx - .5f),seed2 + (4*j/listy - .5f))+
                                o3*Mathf.PerlinNoise(seed2 + (8*i/listx - .5f),seed2 + (8*j/listy - .5f))+
                                o4*Mathf.PerlinNoise(seed2 + (16*i/listx - .5f),seed2 + (16*j/listy - .5f))
                    );

                waterpoint /= 2f;
                waterpoint =Mathf.Pow(waterpoint, power);
                int biome = GetBiome(heightpoint,waterpoint);
                locations.Add(biome);


                //locations.Add(noisepoint);
            }
        }
        convertToMap();
    }
	
    private void convertToMap()
    {
        int num = 0;
        Vector3 nextcoord = new Vector3(0,0,0);

        for(int i = 0; i <listx; i++)
        {
            for(int j = 0; j <listy; j++)
            {
                print(nextcoord);
                switch(locations[i + (j*(int)listy)])
                {
                    case 0:
                    {
                        map.Add(Instantiate (grass, nextcoord, new Quaternion(0,0,0,0)));
                        num+=1;
                        break;
                    }
                    case 1:
                    {
                        map.Add(Instantiate (mountain, nextcoord, new Quaternion(0,0,0,0)));
                        num+=1;
                    break;
                    }
                    case 2:
                    {
                        map.Add(Instantiate (sand, nextcoord, new Quaternion(0,0,0,0)));
                        num+=1;
                    break;
                    }
                    case 3:
                    {
                        map.Add(Instantiate (icy, nextcoord, new Quaternion(0,0,0,0)));
                        num+=1;
                    break;
                    }
                    case 4:
                    {
                        map.Add(Instantiate (scarysand, nextcoord, new Quaternion(0,0,0,0)));
                        num+=1;
                    break;
                    }
                }
                nextcoord= new Vector3(nextcoord.x + .25f, nextcoord.y, nextcoord.z);
                if ((num % listy) == 0)
                {
                    nextcoord= new Vector3(0 , nextcoord.y+.25f, nextcoord.z);
                }
            }
        }
    }


    private int GetBiome(float height, float water)
    {
        if(height<.5f && water<.5f)
        {
            return 0; //grass
        }
        else if(height>.5f && water <.4f)
        {
            return 1; //mountain
        }
        else if(water>.5f && height <.4f)
        {
            return 2; //sand
        }
        else if(height>.5f && water >.4f && water <.7f)
        {
            return 3; //Icy
        }
        else if(water>.5f && height>.4f && height <.7f)
        {
            return 4; //Scary Sand
        }
        else
        {
            return 0;//grassy
    }


    }

	// Update is called once per frame
	void Update () {
		
	}
}
