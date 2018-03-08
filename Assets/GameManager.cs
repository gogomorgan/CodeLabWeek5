using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject PlayerPrefab;
    public GameObject FirePrefab;
    public GameObject TreasurePrefab;

    public float tileWidth = 2f;
    public float tileHeight = 2f;

    public string levelFile = "level1.txt";

    // Use this for initialization
    void Start()
    {

        string levelString = File.ReadAllText(Application.dataPath + Path.DirectorySeparatorChar + levelFile);

        string[] levelLines = levelString.Split('\n');
        int width = 0;

        for (int row = 0; row < levelLines.Length; row++)
        {
            string currentLine = levelLines[row];
            width = currentLine.Length;

            for (int col = 0; col < currentLine.Length; col++)
            {
                char currentChar = currentLine[col];
                if (currentChar == 'x')
                {
                    GameObject FireObj = Instantiate(FirePrefab);
                    FireObj.transform.parent = transform;
                    FireObj.transform.position = new Vector3(col*tileWidth, -row*tileHeight, 0);
                    
                }

                else if (currentChar == 'p')
                {
                    GameObject PlayerObj = Instantiate(PlayerPrefab);
                    PlayerObj.transform.parent = transform;
                    PlayerObj.transform.position = new Vector3(col*tileWidth, -row*tileHeight, 0);
                }

                else if (currentChar == 'e')
                {
                    GameObject TreasureObj = Instantiate(TreasurePrefab);
                    TreasureObj.transform.parent = transform;
                    TreasureObj.transform.position = new Vector3(col*tileWidth, -row*tileHeight, 0);

                }
            }
        }

        float myX = -(width * tileWidth) / 2f + tileWidth / 2f;
        float myY = (levelLines.Length * tileHeight) / 2f - tileHeight / 2f;
        transform.position = new Vector3(myX, myY, 0);

    }

    

    // Update is called once per frame
    void Update () {
		
	}
}
