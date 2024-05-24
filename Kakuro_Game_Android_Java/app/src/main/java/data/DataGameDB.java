package data;

import androidx.annotation.NonNull;

import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QuerySnapshot;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import model.Grid;
import model.Level;

public class DataGameDB {
    public interface QueryAllLevelListener {
        void onQueryAllLevelSuccess(ArrayList<Level> listOfLevels);
        void onQueryAllLevelFailed(String message);
    }
    public interface QueryLevelListener {
        void onQueryLevelSuccess(Level level);
        void onQueryLevelFailed(String message);
    }
    public static void queryAllLevel(final QueryAllLevelListener listener){
        FirebaseFirestore database = FirebaseFirestore.getInstance();
        database.collection("levels").get()
                .addOnSuccessListener(new OnSuccessListener<QuerySnapshot>() {
                    @Override
                    public void onSuccess(QuerySnapshot queryDocumentSnapshots) {
                        List<DocumentSnapshot> snapshotList =  queryDocumentSnapshots.getDocuments();
                        ArrayList<Level> listOfLevels = new ArrayList<>();
                        Level level;
                        for (DocumentSnapshot currentSnapshot : snapshotList) {
                            Map<String, Object> gridMap = (Map<String, Object>) currentSnapshot.getData().get("grid");
                            Grid grid = new Grid(Integer.valueOf(gridMap.get("rows").toString()), Integer.valueOf(gridMap.get("columns").toString()),gridMap.get("datas").toString(), gridMap.get("answerCode").toString(),Integer.valueOf(gridMap.get("gridId").toString()));
                            level = new Level(Integer.valueOf(currentSnapshot.getData().get("levelId").toString()), currentSnapshot.getData().get("description").toString(), grid);
                            listOfLevels.add(level);
                        }
                        listener.onQueryAllLevelSuccess(listOfLevels);
                    }
                })
                .addOnFailureListener(new OnFailureListener() {
                    @Override
                    public void onFailure(@NonNull Exception e) {
                        listener.onQueryAllLevelFailed(e.getMessage());
                    }
                });
    }

    public static void queryLevel(int levelId, final QueryLevelListener listener) {
        FirebaseFirestore database = FirebaseFirestore.getInstance();
        database.collection("levels").whereEqualTo("levelId", levelId).get()
                .addOnSuccessListener(new OnSuccessListener<QuerySnapshot>() {
                    @Override
                    public void onSuccess(QuerySnapshot queryDocumentSnapshots) {
                        List<DocumentSnapshot> snapshotList = queryDocumentSnapshots.getDocuments();
                        Map<String, Object> gridMap = (Map<String, Object>) snapshotList.get(0).getData().get("grid");
                        Grid grid = new Grid(Integer.valueOf(gridMap.get("rows").toString()), Integer.valueOf(gridMap.get("columns").toString()),gridMap.get("datas").toString(), gridMap.get("answerCode").toString(),Integer.valueOf(gridMap.get("gridId").toString()));
                        Level level = new Level(Integer.valueOf(snapshotList.get(0).getData().get("levelId").toString()), snapshotList.get(0).getData().get("description").toString(), grid);
                        listener.onQueryLevelSuccess(level);
                    }
                })
                .addOnFailureListener(new OnFailureListener() {
                    @Override
                    public void onFailure(@NonNull Exception e) {
                        listener.onQueryLevelFailed(e.getMessage());
                    }
                });

    }
}
