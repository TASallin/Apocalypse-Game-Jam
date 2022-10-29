using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Collectibles
{
    public bool[] papers;

    public Collectibles() {
        papers = new bool[9];
    }
}
