package model;

import android.graphics.Color;
import android.util.Log;
import android.view.View;
import android.widget.GridLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.example.kakuro_game_android.R;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import data.CellTag;
import data.DataGameDB;
import data.GamePlayDB;
import data.PlayerAccountDB;
import data.RecordDB;

public class GamePlay implements Serializable {
    private Level level;
    private String playerAnswer;
    private String gamePlayId;
    private int hint;

    public int getHint() {
        return hint;
    }

    public void setHint(int hint) {
        this.hint = hint;
    }

    public Level getLevel() {
        return level;
    }

    public void setLevel(Level level) {
        this.level = level;
    }

    public String getPlayerAnswer() {
        return playerAnswer;
    }

    public void setPlayerAnswer(String playerAnswer) {
        this.playerAnswer = playerAnswer;
    }

    public String getGamePlayId() {
        return gamePlayId;
    }

    public void setGamePlayId(String gamePlayId) {
        this.gamePlayId = gamePlayId;
    }
    public GamePlay(){}
    public GamePlay(Level level, String playerAnswer, String gamePlayId, int hint) {
        this.level = level;
        this.playerAnswer = playerAnswer;
        this.gamePlayId = gamePlayId;
        this.hint = hint;
    }
    public GamePlay(Level level, String playerAnswer, String gamePlayId) {
        this.level = level;
        this.playerAnswer = playerAnswer;
        this.gamePlayId = gamePlayId;
        this.hint = 3;
    }
    public GamePlay(Level level, String gamePlayId) {
        this.level = level;
        this.gamePlayId = gamePlayId;
        this.playerAnswer = null;
        this.hint = 3;
    }
    public interface LoadGameListener {
        void onLoadGameSuccess(GamePlay playGame);
        void onLoadGameFailed(String message);
    }
    public static void startNewGame(int levelId, final LoadGameListener listener) {
            DataGameDB.queryLevel(levelId, new DataGameDB.QueryLevelListener() {
                @Override
                public void onQueryLevelSuccess(Level level) {
                    GamePlayDB.createGamePlay(level, new GamePlayDB.CreationGamePlayListener() {
                        @Override
                        public void onCreateSuccess(GamePlay newGame) {
                            listener.onLoadGameSuccess(newGame);
                        }

                        @Override
                        public void onCreateFailed(String message) {
                            listener.onLoadGameFailed(message);
                        }
                    });
                }
                @Override
                public void onQueryLevelFailed(String message) {
                    listener.onLoadGameFailed(message);
                }
            });
    }

    public static GamePlay continuePreviousGame(Player playerLogin) {
        GamePlay previousGame = playerLogin.getPreviousGame();
        return previousGame;
    }
    public static List<Integer> countMistake(String playerAnswer, String gridAnswer) {
        List<Integer> incorrectIndices = new ArrayList<>();

        if (playerAnswer == null || gridAnswer == null) {
            return incorrectIndices; // Returning an empty list as no valid comparison can be done
        }

        String correctAnswer = gridAnswer;
        String[] playerAnswers = playerAnswer.split("[,;]");
        String[] correctAnswers = correctAnswer.split("[,;]");

        // Loop through the answers and add the index of incorrect answers to the list
        for (int i = 0; i < playerAnswers.length; i++) {
            if (!playerAnswers[i].equals("_") && !playerAnswers[i].equals("") && !correctAnswers[i].equals(playerAnswers[i])) {
                incorrectIndices.add(i);
            }
        }

        return incorrectIndices;
    }
    private String getGridAnswer() {
        return this.getLevel().getGrid().getAnswerCode();
    }
    public interface CheckGameListener {
        void onCheckGameSuccess(List<Integer> mistake);
        void onCheckGameFailed(String message);
    }
    public static void checkAnswer(GamePlay currentGamePlay, String playerAnswer, Player playerLogin, CheckGameListener listener) {
        // Use the method from GamePlay to get the indices of incorrect answers
        String gridAnswer = currentGamePlay.getGridAnswer();
        final List<Integer> mistake = GamePlay.countMistake(playerAnswer, gridAnswer); // ==>   List<Integer> incorrectIndices = currentGamePlay.checkAnswer(playerAnswer);
        if (playerLogin.getAccount() != null) {
            RecordDB.queryRecord(currentGamePlay.getLevel().getLevelId(), playerLogin.getPlayerId(), new RecordDB.QueryRecordListener() {
                @Override
                public void onQuerySuccess(Record record) {
                    RecordDB.updateRecord(record, mistake.size(), false, new RecordDB.UpdateRecordListener() {
                        @Override
                        public void onUpdateSuccess(Record record) {
                            listener.onCheckGameSuccess(mistake);
                        }

                        @Override
                        public void onUpdateFailed(String message) {
                            listener.onCheckGameFailed(message);
                        }
                    });
                }
                @Override
                public void onQueryFailed(String message) {
                    RecordDB.createRecord(currentGamePlay.getLevel().getLevelId(), playerLogin, mistake.size(), 0, new RecordDB.CreationRecordListener() {
                        @Override
                        public void onCreateSuccess(Record record) {
                            listener.onCheckGameSuccess(mistake);
                        }

                        @Override
                        public void onCreateFailed(String message) {
                            listener.onCheckGameFailed(message);
                        }
                    });
                }
            });
        }
        else {
            listener.onCheckGameSuccess(mistake);
        }
    }
    public interface SubmitGameListener {
        void onSubmitGameSuccess(List<Integer> mistake);
        void onSubmitGameFailed(String message);
    }
    public static void submit(GamePlay currentGamePlay, String playerAnswer, Player playerLogin, SubmitGameListener listener) {
        // Use the method from GamePlay to get the indices of incorrect answers
        String gridAnswer = currentGamePlay.getGridAnswer();
        final List<Integer> mistake = GamePlay.countMistake(playerAnswer, gridAnswer); // ==>   List<Integer> incorrectIndices = currentGamePlay.checkAnswer(playerAnswer);
        if (playerLogin.getAccount() != null) {
            RecordDB.queryRecord(currentGamePlay.getLevel().getLevelId(), playerLogin.getPlayerId(), new RecordDB.QueryRecordListener() {
                @Override
                public void onQuerySuccess(Record record) {
                    RecordDB.updateRecord(record, mistake.size(), true, new RecordDB.UpdateRecordListener() {
                        @Override
                        public void onUpdateSuccess(Record record) {
                            listener.onSubmitGameSuccess(mistake);
                        }

                        @Override
                        public void onUpdateFailed(String message) {
                            listener.onSubmitGameFailed(message);
                        }
                    });
                }
                @Override
                public void onQueryFailed(String message) {
                    RecordDB.createRecord(currentGamePlay.getLevel().getLevelId(), playerLogin, mistake.size(), 1, new RecordDB.CreationRecordListener() {
                        @Override
                        public void onCreateSuccess(Record record) {
                            listener.onSubmitGameSuccess(mistake);
                        }

                        @Override
                        public void onCreateFailed(String message) {
                            listener.onSubmitGameFailed(message);
                        }
                    });
                }
            });
        }
        else {
            listener.onSubmitGameSuccess(mistake);
        }

    }

    public static void showHint(View selectedCellView, GridLayout gridLayout, GamePlay currentGamePlay) {
            int[] indices = getCellIndices(selectedCellView, gridLayout);
            int row = indices[0];
            int column = indices[1];
            String correctAnswer = getCorrectAnswer(row, column,gridLayout, currentGamePlay);
            ((TextView) selectedCellView).setText(correctAnswer);
        }

    public static int[] getCellIndices(View cellView, GridLayout gridLayout) {
        int[] indices = new int[2];
        int childCount = gridLayout.getChildCount();
        int index = gridLayout.indexOfChild(cellView);

        if (index != -1) {
            int numRows = gridLayout.getRowCount();
            int numColumns = gridLayout.getColumnCount();

            int rowIndex = index / numColumns;
            int columnIndex = index % numColumns;

            indices[0] = rowIndex;
            indices[1] = columnIndex;
        } else {
            indices[0] = -1;
            indices[1] = -1;
        }

        return indices;
    }
    public static String getCorrectAnswer(int row, int column, GridLayout gridLayout,GamePlay gamePlay ) {
        String correctAnswer = gamePlay.getGridAnswer();
        String[] cells = correctAnswer.split("[,;]");
        int index = row * gridLayout.getColumnCount() + column;
        return cells[index];
    }
    public interface SaveGameListener {
        void onSaveGameSuccess();

        void onSaveGameFailed(String message);
    }
    public static  void saveGame(GamePlay currentGamePlay, Player playerLogin, final SaveGameListener listener){
        PlayerAccountDB.setPreviousGame(currentGamePlay, playerLogin, new PlayerAccountDB.SetPreviousGameListener() {
            @Override
            public void onSetPreviousGameSuccess() {
                // Update successful
                listener.onSaveGameSuccess();
            }
            @Override
            public void onSetPreviousGameFailed(String message) {
                // Update failed
                listener.onSaveGameFailed(message);

            }
        });
    }
}
