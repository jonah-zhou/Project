package data;

import android.content.Intent;
import android.util.Log;
import android.view.View;
import android.widget.Toast;

import androidx.annotation.NonNull;

import com.example.kakuro_game_android.LoginActivity;
import com.example.kakuro_game_android.RegistrationActivity;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.CollectionReference;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.DocumentSnapshot;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.Query;
import com.google.firebase.firestore.QuerySnapshot;

import java.util.List;
import java.util.Map;
import java.util.concurrent.CompletableFuture;

import model.Account;
import model.GamePlay;
import model.Grid;
import model.Level;
import model.Player;

public class PlayerAccountDB  {
    public interface CreationAccountListener {
        void onCreationSuccess(Account account);
        void onCreationFailed(String message);
    }
    public interface QueryAccountListener {
        void onQueryAccountSuccess(Account existingAccount);
        void onQueryAccountFailed(String message);
    }
    public interface QueryPlayerListener {
        void onQueryPlayerSuccess(Player existingPlayer);
        void onQueryPlayerFailed(String message);
    }
    public interface CreationPlayerListener {
        void onCreationSuccess(Player player);
        void onCreationFailed(String message);
    }
    public interface  VerifyCredentialsListener {
        void onVerifySuccess(Account validAccount);
        void onVerifyFailed(String message);
    }
    public static void queryAccount(String email, final QueryAccountListener listener) {

        FirebaseFirestore database =  FirebaseFirestore.getInstance();
        CollectionReference accounts = database.collection("accounts");
        Task<QuerySnapshot> results =  accounts.whereEqualTo("email",email).get();
        results.addOnSuccessListener(new OnSuccessListener<QuerySnapshot>() {
            @Override
            public void onSuccess(QuerySnapshot queryDocumentSnapshots) {
                List<DocumentSnapshot> snapshotList = queryDocumentSnapshots.getDocuments();
                Account account = new Account();
                if (snapshotList.size() > 1) {
                    listener.onQueryAccountFailed("Cannot have 2 accounts with same email");
                }
                else if (snapshotList.size() == 0) {
                    listener.onQueryAccountFailed("No Account has been found");
                }
                else {
                    account.setAccountId(snapshotList.get(0).getData().get("accountId").toString());
                    account.setEmail(snapshotList.get(0).getData().get("email").toString());
                    account.setPassword(snapshotList.get(0).getData().get("password").toString());
                    listener.onQueryAccountSuccess(account);
                }
            }
        }).addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(@NonNull Exception e) {
                listener.onQueryAccountFailed("Account does not exist with email " + email);
            }
        });
    }

    public static void createAccount(String email, String password, final CreationAccountListener listener ) {
        FirebaseAuth mAuth = FirebaseAuth.getInstance();
        mAuth.createUserWithEmailAndPassword(email, password)
                .addOnCompleteListener(task -> {
                    if (task.isSuccessful()) {
                        FirebaseUser firebaseUser = mAuth.getCurrentUser();
                        Account account = new Account();
                        account.setAccountId(firebaseUser.getUid());
                        account.setEmail(email);
                        account.setPassword(password);
                        FirebaseFirestore database = FirebaseFirestore.getInstance();
                        database.collection("accounts").add(account).addOnSuccessListener(a -> listener.onCreationSuccess(account)).addOnFailureListener(e ->listener.onCreationFailed(" Account Creation Failed"));

                    }
                });
    }
    public static void createPlayer(Account account, String playerName, final CreationPlayerListener listener) {
        Player player = new Player(account,playerName,account.getAccountId());
        FirebaseFirestore database = FirebaseFirestore.getInstance();
        database.collection("players").add(player)
                .addOnSuccessListener(a -> listener.onCreationSuccess(player))
                .addOnFailureListener(e -> listener.onCreationFailed("Error"));
    }
    public static void queryPlayer(Account account, final QueryPlayerListener listener) {
        FirebaseFirestore database = FirebaseFirestore.getInstance();
        database.collection("players").whereEqualTo("account", account).get()
                .addOnSuccessListener(new OnSuccessListener<QuerySnapshot>() {
                    @Override
                    public void onSuccess(QuerySnapshot queryDocumentSnapshots) {
                        List<DocumentSnapshot> snapshotList =  queryDocumentSnapshots.getDocuments();
                        Player player = new Player();
                        if (snapshotList.size() > 1) {
                            listener.onQueryPlayerFailed("Cannot have 2 accounts with same email");
                        }
                        else if (snapshotList.size() == 0) {
                            listener.onQueryPlayerFailed("No Account has been found");
                        }
                        else {
                            player.setPlayerName(snapshotList.get(0).getData().get("playerName").toString());
                            player.setPlayerId(snapshotList.get(0).getData().get("playerId").toString());
                            Map<String, Object> playerAccount = (Map<String, Object>) snapshotList.get(0).getData().get("account");
                            player.setAccount(new Account(playerAccount.get("accountId").toString(), playerAccount.get("email").toString(),playerAccount.get("password").toString()));

                            if (snapshotList.get(0).getData().get("previousGame") != null) {

                                Map<String, Object> gamePlayMap = (Map<String, Object>) snapshotList.get(0).getData().get("previousGame");
                                String playerAnswer = gamePlayMap.get("playerAnswer").toString();
                                int hint  = Integer.valueOf(gamePlayMap.get("hint").toString());
                                String gamePlayId = gamePlayMap.get("gamePlayId").toString();
                                Map<String, Object> levelMap = (Map<String, Object>) gamePlayMap.get("level");
                                String description = levelMap.get("description").toString();
                                Integer levelId = Integer.valueOf(levelMap.get("levelId").toString());

                                Map<String, Object> gridMap = (Map<String, Object>) levelMap.get("grid");
                                Grid grid = new Grid(Integer.valueOf(gridMap.get("rows").toString()), Integer.valueOf(gridMap.get("columns").toString()),gridMap.get("datas").toString(), gridMap.get("answerCode").toString(),Integer.valueOf(gridMap.get("gridId").toString()));

                                Level level = new Level(levelId, description, grid);

                                GamePlay previousGame = new GamePlay(level,playerAnswer,gamePlayId, hint);
                                player.setPreviousGame(previousGame);
                            }
                            else {
                                player.setPreviousGame((GamePlay)snapshotList.get(0).getData().get("previousGame"));
                            }


                            listener.onQueryPlayerSuccess(player);
                        }
                    }
                })
                .addOnFailureListener(new OnFailureListener() {
                    @Override
                    public void onFailure(@NonNull Exception e) {
                        listener.onQueryPlayerFailed(e.getMessage());
                    }
                });
    }

    public static void verifyCredentials(String email, String password, final VerifyCredentialsListener listener) {
        queryAccount(email, new QueryAccountListener() {
            @Override
            public void onQueryAccountSuccess(Account account) {
                if (account.getPassword().equals(password)) {
                    FirebaseAuth mAuth = FirebaseAuth.getInstance();
                    mAuth.signInWithEmailAndPassword(email, password)
                            .addOnSuccessListener(new OnSuccessListener<AuthResult>() {
                                @Override
                                public void onSuccess(AuthResult authResult) {
                                    listener.onVerifySuccess(account);
                                }
                            })
                            .addOnFailureListener(new OnFailureListener() {
                                @Override
                                public void onFailure(@NonNull Exception e) {
                                    listener.onVerifyFailed(e.getMessage());
                                }
                            });

                }
                else {
                    listener.onVerifyFailed("Password is incorrect");
                }
            }

            @Override
            public void onQueryAccountFailed(String message) {
                listener.onVerifyFailed(message);
            }
        });
    }
    public interface SetPreviousGameListener {
        void onSetPreviousGameSuccess();
        void onSetPreviousGameFailed(String message);
    }
    public static void setPreviousGame(GamePlay previousGame, Player playerLogin, final SetPreviousGameListener listener) {
        FirebaseFirestore database = FirebaseFirestore.getInstance();
        CollectionReference playersCollection = database.collection("players");

        // Query players collection to find the player document with the specified account ID
        playersCollection.whereEqualTo("account.accountId", playerLogin.getAccount().getAccountId()).get()
                .addOnSuccessListener(new OnSuccessListener<QuerySnapshot>() {
                    @Override
                    public void onSuccess(QuerySnapshot queryDocumentSnapshots) {
                        List<DocumentSnapshot> snapshotList = queryDocumentSnapshots.getDocuments();
                        if (snapshotList.size() > 1) {
                            // Handle error: More than one player found
                            listener.onSetPreviousGameFailed("More than one player found with the same account");
                        } else if (snapshotList.size() == 0) {
                            // Handle error: No player found
                            listener.onSetPreviousGameFailed("No player found with the specified account");
                        } else {
                            // Player document found, update the previous game
                            DocumentSnapshot playerSnapshot = snapshotList.get(0);
                            Player player = playerSnapshot.toObject(Player.class);
                            if (player != null) {
                                player.setPreviousGame(previousGame);
                                // Update the player document with the new previous game
                                playersCollection.document(playerSnapshot.getId()).set(player)
                                        .addOnSuccessListener(new OnSuccessListener<Void>() {
                                            @Override
                                            public void onSuccess(Void aVoid) {
                                                // Update successful
                                                listener.onSetPreviousGameSuccess();
                                            }
                                        })
                                        .addOnFailureListener(new OnFailureListener() {
                                            @Override
                                            public void onFailure(@NonNull Exception e) {
                                                // Error updating player
                                                listener.onSetPreviousGameFailed(e.getMessage());
                                            }
                                        });
                            } else {
                                // Handle error: Player data is null
                                listener.onSetPreviousGameFailed("Error: Player data is null");
                            }
                        }
                    }
                })
                .addOnFailureListener(new OnFailureListener() {
                    @Override
                    public void onFailure(@NonNull Exception e) {
                        // Handle failure: Firestore query failed
                        listener.onSetPreviousGameFailed(e.getMessage());
                    }
                });
    }

}
