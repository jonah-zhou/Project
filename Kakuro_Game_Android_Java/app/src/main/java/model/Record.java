package model;

import java.io.Serializable;
import java.util.ArrayList;

import data.RecordDB;

public class Record implements Serializable {
    Level level;
    Player player;
    int repetition;
    int mistake;

    public Record() {}

    public Record(Level level, Player player, int repetition, int mistake) {
        this.level = level;
        this.player = player;
        this.repetition = repetition;
        this.mistake = mistake;
    }

    public Level getLevel() {
        return level;
    }

    public void setLevel(Level level) {
        this.level = level;
    }

    public Player getPlayer() {
        return player;
    }

    public void setPlayer(Player player) {
        this.player = player;
    }

    public int getRepetition() {
        return repetition;
    }

    public void setRepetition(int repetition) {
        this.repetition = repetition;
    }

    public int getMistake() {
        return mistake;
    }

    public void setMistake(int mistake) {
        this.mistake = mistake;
    }

    @Override
    public String toString() {
        return player.getPlayerName();
    }
    public interface GetRankListener {
        void onGetRankSuccess(ArrayList<Record> players);
        void onGetRankFailed(String message);
    }
    public static void getRankByLevel(int levelId, final GetRankListener listener) {
            RecordDB.queryTopPlayers(levelId, new RecordDB.QueryRecordsListener() {
                @Override
                public void onQuerySuccess(ArrayList<Record> topPlayers) {
                    listener.onGetRankSuccess(topPlayers);
                }

                @Override
                public void onQueryFailed(String message) {
                    listener.onGetRankFailed(message);
                }
            });
    }
}
