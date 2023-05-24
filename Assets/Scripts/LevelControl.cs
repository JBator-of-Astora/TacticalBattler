using UnityEngine;
using System.Collections.Generic;

namespace LevelControl {

    public class LevelInfo
    {
        public int rows;
        public int columns;
    } 
    
    public class Map
    {
        // First number is the level
        // Next 2 numbers are the x and z coordinates of tiles on that level
        Tile[,,] map;

        int height;
        int rows;
        int columns;

        public Map(string [] lines, int rows_p, int columns_p) {
            rows = rows_p;
            columns = columns_p;
            height = lines.Length / rows;

            map = new Tile[lines.Length / rows, rows, columns];

            int rowNum = 0;
            int currentHeight = 0;
            foreach (string line in lines) {

                if (rowNum == rows) {
                    rowNum = 0;
                    currentHeight++;
                }

                string[] splitLine = line.Split(",");
                
                for (int z = 0; z < columns; z++) {
                    
                    TileType temp;
                    if (System.Enum.TryParse<TileType>(splitLine[z], out temp)) {
                        map[currentHeight, rowNum, z] = new Tile(temp);
                    } else
                    {
                        Debug.Log(splitLine[z] + "enum type not found");
                    }

                }

                rowNum++;
            }

        }

        // For Debugging Purposes
        public void output_map() {
            for (int h = 0; h < height; h++) {
                
                for (int r = 0; r < rows; r++) {

                    for (int c = 0; c < columns; c++) {
                        Debug.Log("Height: " + h + ",Row: " + r + ",Column: " + c);
                        Debug.Log(map[h,r,c].type);
                    }
                }
            }
        }

        public void populate_world(ref GameObject[] tiles) {
            
            for (int h = 0; h < height; h++) {

                for (int r = 0; r < rows; r++) {

                    for (int c = 0; c < columns; c++) {
                        
                        TileType type = map[h,r,c].type;
                        Vector3 position = new Vector3(r, h, c);
                        
                        if (type != TileType.None) {
                            GameObject.Instantiate(tiles[(int)type], position, Quaternion.identity);
                        } 
                    }
                } 
            }
        }
        
        // NOTE: Need to think about discovery list sorting schema to figure out what is the most efficient way of dealing with it
        // Although this might not be needed at the map sizes we are working at
        public List<TileNode> get_path((int, int, int) start, (int, int, int) end) {

            // Discovered nodes that we may look at if the other paths we look at do not pan out
            List<int> discovered = new List<int>();

            // For this algorithm we need to know the best path to get to some node through the optimal predecessor
            // For each node we create, we will give it an indice to this list that we can look up its predecessor in
            // along with itself;

            List<TileNode> tileNodes = new List<TileNode>();

            // Adding First Node to Discovered
            // G score of start should be zero
            // Set H value

            TileNode start = new TileNode(map[start.Item1, start.Item2, start.Item3], 0);
            start.set_g(0);
            start.calculate_h();

            discovered.Add(0);
            tileNodes.Add(start);

            while (discovered.Count != 0) {

                // Make Current equal to node in discovered with lowest f score
                // If current is the goal. We are done

                // Otherwise remove current from discovered

                // for each neighbor of our current node

                    // We create a tentative g score for the neighbor which is the cost to current plus cost to neighbor

                    // If this tentative g score is better than the current g score of the neighbor, we have a better path to that neighbor
                        // We set predecessor of neighbor to current node
                        // We update g and f score of neighbor
                        // Also we add it to discovered set if it is not in discovered set
                    
            }

            // If we go through the entire discovery set and do not hit the end, we have failed
        }

        public int get_height() {
            return height;
        }

        public int get_rows() {
            return rows;
        }

        public int get_columns() {
            return columns;
        }

        public Tile get_tile((int, int, int) location) {
            return map[location.Item1, location.Item2, location.Item3];
        }
    }

    public class Tile 
    {
        public TileType type;
        public GameObject occupant;

        public Tile(TileType type_p) {
            type = type_p;
            occupant = null;
        }
    }

    public enum TileType
    {
        None = -1,
        FullTile = 0,
        HalfTile = 1,
    }

    // Used for pathing 
    public class TileNode 
    {
        public Tile tile;

        private int f;
        private int g;
        private int h;

        private int predecessor;
        private int index;

        public TileNode(Tile tile_p, int index_p) {

            tile = tile_p;
            index = index_p;

            predecessor = -1;
            
            // We will consider -1 infinity
            f = -1;
            g = -1;
            h = -1;
        } 

        public int get_index() {
            return index;
        }

        public int get_predecessor() {
            return predecessor;
        }

        // TODO
        public void calculate_h((int, int, int) goal) {
            
        }

        // TODO
        public void calculate_g(int predecessor_p, ref List<TileNode> allNodes) {

        }

        public void set_g(int g_p) {
            g = g_p;
        }

        // Every Time We Update H or G we Update F
        private void update_f() {
            f = g + h;
        }

        public int get_f() {
            return f;
        }

        public int get_h() {
            return h;
        }

        public int get_g() {
            return g;
        }
    }
}
