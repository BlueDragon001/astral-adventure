using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelGrid {
    private int[,,] grid;

    public VoxelGrid(int xSize, int ySize, int zSize) {
        grid = new int[xSize, ySize, zSize];
    }

    public int GetVoxel(int x, int y, int z) {
        if (x >= 0 && x < grid.GetLength(0) &&
            y >= 0 && y < grid.GetLength(1) &&
            z >= 0 && z < grid.GetLength(2)) {
            return grid[x, y, z];
        }
        return 0;
    }

    public void SetVoxel(int x, int y, int z, int value) {
        if (x >= 0 && x < grid.GetLength(0) &&
            y >= 0 && y < grid.GetLength(1) &&
            z >= 0 && z < grid.GetLength(2)) {
            grid[x, y, z] = value;
        }
    }
}

