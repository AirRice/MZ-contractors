using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    public TextAsset cardsData;
    public List<FacilityCard> facilities = new();

    private void Awake()
    {
        //enforce singleton
        if (gameController == null)
            gameController = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GetCardsData();
    }
    private readonly ConstructionResource[] headerResources = { 
        ConstructionResource.HR, 
        ConstructionResource.Steel, 
        ConstructionResource.Glass, 
        ConstructionResource.Concrete, 
        ConstructionResource.Machinery 
    };

    void GetCardsData()
    {
        String[] fileLines = Regex.Split(cardsData.text, "\n|\r\n");
        fileLines = fileLines.Skip(1).ToArray();
        foreach (String line in fileLines)
        {   
            Debug.Log(line);
            string[] values = Regex.Split(line, ","); //file is split by comma
            Regex regex = new Regex(@"([a-zA-Z]+) (\d+)");
            int[] intValues = new int[6];
            for (int i = 0; i < 6; i++)
            {
                int val = 0;
                bool flag  = int.TryParse(values[i], out val);
                if (flag) 
                    intValues[i - 1] = val;
                else 
                    intValues[i - 1] = 0;
            }
            FacilityCard card = null;
            // if first value (cost) == 110
            if (intValues[0] == 110)
            {
                card = FacilityCard.CreateInstanceGoal(intValues[0], intValues[1], intValues[2], intValues[3], intValues[4], intValues[5]);
            }
            else
            {
                Match match = regex.Match(values[6]);
                Debug.Log(match.Groups[1].Value);
                Debug.Log(match.Groups[2].Value);
                card = FacilityCard.CreateInstance(intValues[0], intValues[1], intValues[2], intValues[3], intValues[4], intValues[5], match.Groups[1].Value, int.Parse(match.Groups[2].Value));
            }
            if (card != null)
            {
                facilities.Add(card);
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
