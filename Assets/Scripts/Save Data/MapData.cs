using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    public class MapNode
    {
        public string locationName {get; set;}
        public bool activated {get; set;}
        public MapNode(string nameInput)
        {
            locationName = nameInput;
            activated = false;
        }
    }

    /*
    Homebases
    */
    public Dictionary<string, MapNode> homeBases = new Dictionary<string, MapNode>();

    /*
    Dungeons
    */
    public Dictionary<string, MapNode> dungeons = new Dictionary<string, MapNode>();

    /*
    Side Stories
    */
    public Dictionary<string, MapNode> sideStories = new Dictionary<string, MapNode>();
    public MapData()
    {
        // TODO: Generate the default list of MapNodes when a new MapData is created

    }
}
