using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelControl;

// DECIDED TO PUT ALL OF THIS CODE INTO THE ACTUAL MAP CLASS IN LEVELCONTROL FOR NOW


/*
namespace Pathing {

    public class Path {

        List<(int, int, int)> locations;

        List<Node> toSearch;
        List<Node> processed;

        // Based off Implementation by Tarodev
        public Path((int, int, int) start_index, (int, int, int) end_index, ref Map map) {
            toSearch = new List<Node>();
            processed = new List<Node>();
            
            Node beginning = new Node(map.get_tile((start_index.Item1, start_index.Item2, start_index.Item3)), (start_index.Item1, start_index.Item2, start_index.Item3));
            Node target = new Node(map.get_tile((end_index.Item1, end_index.Item2, end_index.Item3)), (end_index.Item1, end_index.Item2, end_index.Item3));

            beginning.f = 0;
            beginning.g = 0;
            
            toSearch.Add(beginning);

            while(toSearch.Count != 0) {

                Node current = toSearch[0];

                foreach(Node n in toSearch){
                    
                    if (n.f < current.f || n.f == current.f && n.h < current.h) {
                        current = n;
                    }
                }

                processed.Add(current);
                toSearch.Remove(current);

                for (int i = -1; i < 2; i++) {

                for (int j = -1; j < 2; j++) {
                    
                    // Checks if variables are valid indices
                    bool validX = (current.location.Item2 + i) < map.get_columns();
                    bool validY = (current.location.Item3 + j) < map.get_rows();

                    if ((i == 0 && j == 0) && validX && validY) {
                        
                        // We want the highest block possible
                        for (int h = map.get_height() - 1; h >= 0; h--) {

                            bool inProcessed = false;

                            foreach (Node n in processed) {

                                    if (n.location == (h, current.location.Item2 + i, current.location.Item3 + j)) {
                                        inProcessed = true;
                                        break;
                                    }
                                }

                            if (map.get_tile((h, current.location.Item2 + i, current.location.Item3 + j)).type != TileType.None && !inProcessed) {

                                Node neighbor = new Node(map.get_tile((h, current.location.Item2 + i, current.location.Item3 + j)), (h, current.location.Item2 + i, current.location.Item3 + j));

                                // Checking if toSearch containst this Node

                                bool inToSearch = false;
                                foreach (Node n in toSearch) {

                                    if (n.location == (h, current.location.Item2 + i, current.location.Item3 + j)) {
                                        inToSearch = true;
                                        break;
                                    }
                                }


                                if (!inToSearch || get_distance(current, neighbor) < neighbor.g) {
                                    neighbor.g = get_distance(current, neighbor);

                                    if (!inToSearch) {
                                        neighbor.h = get_distance(neighbor, target);
                                    }
                                }
                                
                            }
                        }
                   }   
                }
            }

            }
        }

        private int get_distance(Node start, Node end) {
            if (start == end) {
                return 0;
            }

            var zSq = Mathf.Pow((start.location.Item1 - end.location.Item1), 2);
            var xSq = Mathf.Pow((start.location.Item2 - end.location.Item2), 2);
            var ySq = Mathf.Pow((start.location.Item3 - end.location.Item3), 2);

            return (int) Mathf.Sqrt(zSq + xSq + ySq);
        }

        public List<(int, int, int)> get_locations((int, int, int) start_index, (int, int, int) end_index) {

            locations = new List<(int, int, int)>();

            (int, int, int) current = start_index;

            while (current != end_index) {

                (int, int, int) path;
                int fVal = -1;

                for (int i = -1; i < 2; i++) {
                    for (int j = -1; j < 2; j++) {
                        for (int h = map.get_height() - 1; h >= 0; h--) {

                            
                        }
                    }
                }

                locations.Add(current);
                current = path; 

            }
            return locations;
        }
    }

    public class Node {
        public Tile tile;
        
        public int f;
        public int g;
        public int h;

        public (int, int, int) location;

        // Basic Contructor for the source
        public Node(Tile tile_p, (int, int, int) location_p) {
            f = 0;
            g = 0;
            h = 0;

            tile = tile_p;
            location = location_p;
        }
    }
}

*/