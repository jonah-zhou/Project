package data;

import androidx.annotation.NonNull;

import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.CollectionReference;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.FieldValue;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QuerySnapshot;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;

import model.Grid;
import model.Record;
import model.Account;
import model.GamePlay;
import model.Level;
import model.Player;

public class RecordDB {
    public interface QueryRecordsListener {
        void onQuerySuccess(ArrayList<Record> players);
        void onQueryFailed(String message);
    }
    public static void queryTopPlayers(int levelId, final QueryRecordsListener listener) {
        FirebaseFirestore database = FirebaseFirestore.getInstance();
        CollectionReference records = database.collection("records");
        Task<QuerySnapshot> results = records.whereEqualTo("level.levelId", levelId).get();
        results.addOnSuccessListener(new OnSuccessListener<QuerySnapshot>() {
            @Override
            public void onSuccess(QuerySnapshot queryDocumentSnapshots) {
                List<DocumentSnapshot> snapshotList =  queryDocumentSnapshots.getDocuments();
                ArrayList<Record> listOfRecords = new ArrayList<>();
                for (DocumentSnapshot currentSnapshot : snapshotList) {
                    int repetition = Integer.valueOf(currentSnapshot.getData().get("repetition").toString());
                    if (repetition > 0) {
                        Map<String, Object> levelMap = (Map<String, Object>) currentSnapshot.getData().get("level");
                        String description = levelMap.get("description").toString();
                        int levelId = Integer.valueOf(levelMap.get("levelId").toString());

                        Map<String, Object> gridMap = (Map<String, Object>) levelMap.get("grid");
                        String answerCode = gridMap.get("answerCode").toString();
                        int columns = Integer.valueOf(gridMap.get("columns").toString());
                        String datas = gridMap.get("datas").toString();
                        int gridId = Integer.valueOf(gridMap.get("gridId").toString());
                        int rows = Integer.valueOf(gridMap.get("rows").toString());
                        Grid grid = new Grid(rows, columns, datas, answerCode, gridId);

                        Level level = new Level(levelId,description,grid);

                        Map<String, Object> playerMap = (Map<String, Object>) currentSnapshot.getData().get("player");

                        Map<String, Object> accountMap = (Map<String, Object>) playerMap.get("account");
                        String accountId = accountMap.get("accountId").toString();
                        String email = accountMap.get("email").toString();
                        String password = accountMap.get("password").toString();

                        Account account = new Account(accountId, email, password);

                        String playerId = playerMap.get("playerId").toString();
                        String playerName = playerMap.get("playerName").toString();
                        Player player = new Player(account,playerName,playerId);
                        int mistake = Integer.valueOf(currentSnapshot.getData().get("mistake").toString());

                        Record record = new Record(level,player,repetition, mistake);

                        listOfRecords.add(record);
                    }

                }
                for (int i = 0; i < listOfRecords.stream().count() - 1; i++) {
                    for (int j = 0; j < listOfRecords.stream().count() - 1; j++) {
                        if (listOfRecords.get(j).getMistake() > listOfRecords.get(j + 1).getMistake()) {
                            Record temp = listOfRecords.get(j);
                            listOfRecords.set(j, listOfRecords.get(j + 1));
                            listOfRecords.set(j + 1, temp);
                        }
                        else if (listOfRecords.get(j).getMistake() == listOfRecords.get(j + 1).getMistake()) {
                            if (listOfRecords.get(j).getRepetition() < listOfRecords.get(j + 1).getRepetition()) {
                                Record temp = listOfRecords.get(j);
                                listOfRecords.set(j, listOfRecords.get(j + 1));
                                listOfRecords.set(j + 1, temp);
                            }
                        }
                    }
                }
                ArrayList<Record> topPlayers = listOfRecords;
                listener.onQuerySuccess(topPlayers);
            }
        }).addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(@NonNull Exception e) {
                listener.onQueryFailed(e.getMessage());
            }
        });
    }
    public interface CreationRecordListener {
        void onCreateSuccess(Record record);
        void onCreateFailed(String message);
    }
    public static void createRecord(int levelId, Player playerLogin, int mistake, int repetition, final CreationRecordListener listener ) {
        String recordId = UUID.randomUUID().toString();
        FirebaseFirestore database = FirebaseFirestore.getInstance();
        DataGameDB.queryLevel(levelId, new DataGameDB.QueryLevelListener() {
            @Override
            public void onQueryLevelSuccess(Level level) {
                Record record = new Record(level, playerLogin,repetition, mistake);
                DocumentReference docRef =  database.collection("records").document(recordId);
                docRef.set(record).addOnSuccessListener(new OnSuccessListener<Void>() {
                    @Override
                    public void onSuccess(Void unused) {
                        listener.onCreateSuccess(record);
                    }
                }).addOnFailureListener(new OnFailureListener() {
                    @Override
                    public void onFailure(@NonNull Exception e) {
                        listener.onCreateFailed(e.getMessage());
                    }
                });
            }
            @Override
            public void onQueryLevelFailed(String message) {
                listener.onCreateFailed(message);
            }
        });
    }
    public interface GetMistakeListener {
        void onGetMistakeSuccess(Integer mistake);
        void onGetMistakeFailed(String message);
    }

    public static void getMistake(Level level, String playerId, final GetMistakeListener listener) {
        FirebaseFirestore database = FirebaseFirestore.getInstance();
        CollectionReference records = database.collection("records");
        records.whereEqualTo("level.levelId", level.getLevelId())
                .whereEqualTo("player.playerId", playerId)
                .get()
                .addOnSuccessListener(new OnSuccessListener<QuerySnapshot>() {
                    @Override
                    public void onSuccess(QuerySnapshot queryDocumentSnapshots) {
                        if (!queryDocumentSnapshots.isEmpty()) {
                            int mistake = queryDocumentSnapshots.getDocuments().get(0).getLong("mistake").intValue();
                            listener.onGetMistakeSuccess(mistake);

                        } else {
                            listener.onGetMistakeFailed("Record not found for the specified level and player.");
                        }
                    }
                })
                .addOnFailureListener(new OnFailureListener() {
                    @Override
                    public void onFailure(@NonNull Exception e) {
                        listener.onGetMistakeFailed(e.getMessage());
                    }
                });
    }

    public interface QueryRecordListener {
        void onQuerySuccess(Record record);
        void onQueryFailed(String message);
    }
    public static void queryRecord(int levelId, String playerLoginId, final RecordDB.QueryRecordListener listener) {
        FirebaseFirestore database = FirebaseFirestore.getInstance();
        CollectionReference records = database.collection("records");
        Task<QuerySnapshot> results = records.whereEqualTo("level.levelId", levelId).whereEqualTo("player.playerId",playerLoginId).get();
        results.addOnSuccessListener(new OnSuccessListener<QuerySnapshot>() {
            @Override
            public void onSuccess(QuerySnapshot queryDocumentSnapshots) {
                List<DocumentSnapshot> snapshotList =  queryDocumentSnapshots.getDocuments();
                ArrayList<Record> listOfRecords = new ArrayList<>();
                for (DocumentSnapshot currentSnapshot : snapshotList) {

                    Map<String, Object> levelMap = (Map<String, Object>) currentSnapshot.getData().get("level");
                    String description = levelMap.get("description").toString();
                    int levelId = Integer.valueOf(levelMap.get("levelId").toString());

                    Map<String, Object> gridMap = (Map<String, Object>) levelMap.get("grid");
                    String answerCode = gridMap.get("answerCode").toString();
                    int columns = Integer.valueOf(gridMap.get("columns").toString());
                    String datas = gridMap.get("datas").toString();
                    int gridId = Integer.valueOf(gridMap.get("gridId").toString());
                    int rows = Integer.valueOf(gridMap.get("rows").toString());
                    Grid grid = new Grid(rows, columns, datas, answerCode, gridId);

                    Level level = new Level(levelId,description,grid);

                    Map<String, Object> playerMap = (Map<String, Object>) currentSnapshot.getData().get("player");

                    Map<String, Object> accountMap = (Map<String, Object>) playerMap.get("account");
                    String accountId = accountMap.get("accountId").toString();
                    String email = accountMap.get("email").toString();
                    String password = accountMap.get("password").toString();

                    Account account = new Account(accountId, email, password);

                    String playerId = playerMap.get("playerId").toString();
                    String playerName = playerMap.get("playerName").toString();
                    Player player = new Player(account,playerName,playerId);
                    int mistake = Integer.valueOf(currentSnapshot.getData().get("mistake").toString());
                    int repetition = Integer.valueOf(currentSnapshot.getData().get("repetition").toString());
                    Record record = new Record(level,player,repetition, mistake);
                    listOfRecords.add(record);
                }
                boolean isFound = false;
                for (Record currentRecord : listOfRecords) {
                    if (currentRecord.getLevel().getLevelId() == levelId && currentRecord.getPlayer().getPlayerId().equals(playerLoginId)) {
                        isFound = true;
                        listener.onQuerySuccess(currentRecord);
                    }
                }
                if (!isFound) {
                    listener.onQueryFailed("Can not find the record");
                }
            }
        }).addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(@NonNull Exception e) {
                listener.onQueryFailed(e.getMessage());
            }
        });
    }
    public interface UpdateRecordListener {
        void onUpdateSuccess(Record record);
        void onUpdateFailed(String message);
    }
    public static void updateRecord(Record record, int mistake, boolean isUpdateRep, final UpdateRecordListener listener) {
        FirebaseFirestore database = FirebaseFirestore.getInstance();
        CollectionReference records = database.collection("records");
        Task<QuerySnapshot> results = records.whereEqualTo("level.levelId", record.getLevel().getLevelId()).whereEqualTo("player.playerId",record.getPlayer().getPlayerId()).get();
        results.addOnSuccessListener(new OnSuccessListener<QuerySnapshot>() {
            @Override
            public void onSuccess(QuerySnapshot queryDocumentSnapshots) {
                DocumentSnapshot documentSnapshot = queryDocumentSnapshots.getDocuments().get(0);
                String documentId = documentSnapshot.getId();
                int newMistake = record.getMistake() + mistake;
                int newRep = record.getRepetition();
                if (isUpdateRep == true) {
                    newRep += 1;
                }
                record.setMistake(newMistake);
                record.setRepetition(newRep);
                Map<String, Object> updateRecord = new HashMap<>();
                updateRecord.put("mistake", newMistake);
                updateRecord.put("repetition", newRep);
                database.collection("records").document(documentId).update(updateRecord).addOnSuccessListener(new OnSuccessListener<Void>() {
                    @Override
                    public void onSuccess(Void unused) {
                        listener.onUpdateSuccess(record);
                    }
                }).addOnFailureListener(new OnFailureListener() {
                    @Override
                    public void onFailure(@NonNull Exception e) {
                        listener.onUpdateFailed(e.getMessage());
                    }
                });
            }
        }).addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(@NonNull Exception e) {

            }
        });
    }
}
