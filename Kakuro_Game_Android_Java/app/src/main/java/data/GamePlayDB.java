package data;

import androidx.annotation.NonNull;

import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QuerySnapshot;

import java.util.UUID;

import model.GamePlay;
import model.Level;
import model.Player;
import model.Record;

public class GamePlayDB {
    public interface CreationGamePlayListener {
        void onCreateSuccess(GamePlay gamePlay);
        void onCreateFailed(String message);
    }
    public static void createGamePlay(Level level, final CreationGamePlayListener listener) {
        String gamePlayId = UUID.randomUUID().toString();
        FirebaseFirestore database = FirebaseFirestore.getInstance();
        GamePlay gamePlay = new GamePlay(level, gamePlayId);
        DocumentReference docRef =  database.collection("gameplays").document(gamePlayId);
        docRef.set(gamePlay)
                .addOnSuccessListener(new OnSuccessListener<Void>() {
                    @Override
                    public void onSuccess(Void unused) {
                        listener.onCreateSuccess(gamePlay);
                    }
                })
                .addOnFailureListener(new OnFailureListener() {
                    @Override
                    public void onFailure(@NonNull Exception e) {
                        listener.onCreateFailed(e.getMessage());
                    }
                });
    }


}
