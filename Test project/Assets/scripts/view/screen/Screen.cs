using UnityEngine;
using System.Collections.Generic;
using System;

public class Screen {

    public readonly  List<string> tokens;
    public readonly string levelName;

    public Screen(string levelName, List<string> tokens)
    {
        this.levelName = levelName;
        this.tokens = new List<string>(tokens);
    }

}
