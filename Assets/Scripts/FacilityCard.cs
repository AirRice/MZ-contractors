using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConstructionResource
{
    None,
    HR,
    Steel,
    Glass,
    Concrete,
    Machinery
}

public class FacilityCard : ScriptableObject
{
    public string facilityName;
    public readonly Dictionary<string, ConstructionResource> strToResource = new Dictionary<string, ConstructionResource>
    {
        { "HR", ConstructionResource.HR },
        { "steel", ConstructionResource.Steel },
        { "glass", ConstructionResource.Glass },
        { "concrete", ConstructionResource.Concrete },
        { "machinery", ConstructionResource.Machinery }
    };
    public int costValue = 0;
    public bool isGoal = false;
    public Dictionary<ConstructionResource, int> resourcesDict = new();
    public (ConstructionResource, int) producedResource = (ConstructionResource.None, 0);
    public void AddResourceEntry(ConstructionResource resource, int amount)
    {
        resourcesDict.Add(resource, amount);
    }
    public void SetProducedResource(ConstructionResource resource, int amount) {
        producedResource = (resource, amount);
    }
    public static FacilityCard CreateInstance(int costval, int hrvalue, int steelvalue, int glassvalue, int concretevalue, int machineryvalue, string produced, int productionvalue) 
    {
        FacilityCard fc = CreateInstance<FacilityCard>();
        fc.costValue = costval;
        fc.AddResourceEntry(fc.strToResource["HR"], hrvalue);
        fc.AddResourceEntry(fc.strToResource["steel"], steelvalue);
        fc.AddResourceEntry(fc.strToResource["glass"], glassvalue);
        fc.AddResourceEntry(fc.strToResource["concrete"], concretevalue);
        fc.AddResourceEntry(fc.strToResource["machinery"], machineryvalue);
        fc.SetProducedResource(fc.strToResource[produced], productionvalue);
        fc.isGoal = false;
        return fc;
    }
    public static FacilityCard CreateInstanceGoal(int costval, int hrvalue, int steelvalue, int glassvalue, int concretevalue, int machineryvalue)
    {
        FacilityCard fc = CreateInstance<FacilityCard>();
        fc.costValue = costval;
        fc.AddResourceEntry(fc.strToResource["HR"], hrvalue);
        fc.AddResourceEntry(fc.strToResource["steel"], steelvalue);
        fc.AddResourceEntry(fc.strToResource["glass"], glassvalue);
        fc.AddResourceEntry(fc.strToResource["concrete"], concretevalue);
        fc.AddResourceEntry(fc.strToResource["machinery"], machineryvalue);
        fc.isGoal = true;

        return fc;
    }

}
