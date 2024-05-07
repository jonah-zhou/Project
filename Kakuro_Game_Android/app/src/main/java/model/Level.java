package model;

import java.io.Serializable;
import java.util.ArrayList;

import data.DataGameDB;

public class Level implements Serializable {
    private int levelId;
    private String description;
    private Grid grid;
    public Level(int levelId, String description, Grid grid) {
        this.levelId = levelId;
        this.description = description;
        this.grid = grid;
    }
    public Level() {

    }
    public int getLevelId() {
        return levelId;
    }

    public void setLevelId(int levelId) {
        this.levelId = levelId;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public Grid getGrid() {
        return grid;
    }

    public void setGrid(Grid grid) {
        this.grid = grid;
    }
    public interface QueryAllLevelListener {
        void onQueryAllLevelSuccess(ArrayList<Level> listOfLevels);
        void onQueryAllLevelFailed(String message);
    }
    public static void getListLevel(Level.QueryAllLevelListener listener){
        DataGameDB.queryAllLevel(new DataGameDB.QueryAllLevelListener() {
            @Override
            public void onQueryAllLevelSuccess(ArrayList<Level> listOfLevels) {
                listener.onQueryAllLevelSuccess(listOfLevels);
            }
            @Override
            public void onQueryAllLevelFailed(String message) {
                listener.onQueryAllLevelFailed(message);
            }
        });
    }

    @Override
    public String toString() {
        return "Level{" +
                "levelId=" + levelId +
                ", description='" + description + '\'' +
                ", grid=" + grid +
                '}';
    }
}
