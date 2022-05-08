using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element
{
    public string elementName;
    public string atomicSymbol;
    public int numProtons; //also known as atomic number
    public int[] electrons; // grouped by number, from inside out
    public int numNeutrons;
    public string usage;
    public string[] properties;
}

public class Elements : MonoBehaviour
{
    public List<Element> elementsList = new();

    public void Init()
    {
        elementsList.Add(new Element
        {
            elementName = "Hydrogen",
            atomicSymbol = "H",
            numProtons = 1,
            electrons = new[] {1},
            numNeutrons = 0,
            usage = "Sun and stars",
            properties = new[] {"Human Body", "colourless gas"}
        });
        elementsList.Add(new Element
        {
            elementName = "Helium",
            atomicSymbol = "He",
            numProtons = 2,
            electrons = new[] {2},
            numNeutrons = 2,
            usage = "Balloons",
            properties = new[] {"colourless gas"}
        });
        elementsList.Add(new Element
        {
            elementName = "Lithium",
            atomicSymbol = "Li",
            numProtons = 3,
            electrons = new[] {2, 1},
            numNeutrons = 4,
            usage = "Batteries",
            properties = new[] {"metallic solid"}
        });
        elementsList.Add(new Element
        {
            elementName = "Beryllium",
            atomicSymbol = "Be",
            numProtons = 4,
            electrons = new[] {2, 2},
            numNeutrons = 5,
            usage = "Emeralds",
            properties = new[] {"metallic solid"}
        });
        elementsList.Add(new Element
        {
            elementName = "Boron",
            atomicSymbol = "B",
            numProtons = 5,
            electrons = new[] {2, 2, 1},
            numNeutrons = 5,
            usage = "Sports Equipment",
            properties = new[] {"black solid"}
        });

        //...and so many more
        elementsList.Add(new Element
        {
            elementName = "Test",
            atomicSymbol = "T",
            numProtons = 1,
            electrons = new[] {3, 2, 1},
            numNeutrons = 5,
            usage = "test",
            properties = new[] {"test"}
        });
    }

    public Element GetElementByName(string elName)
    {
        return elementsList.Find(x => x.elementName == elName);
    }
}