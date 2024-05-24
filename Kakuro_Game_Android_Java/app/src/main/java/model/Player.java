package model;

import java.io.Serializable;

import data.PlayerAccountDB;

public class Player implements Serializable {
    public interface ProcessListener {
        void onProcessSuccess(Player player);
        void onProcessFailed(String message);
    }
    private Account account; // This is the Firebase Authentication User ID
    private String playerId;
    private String playerName;
    private GamePlay previousGame;
    public Account getAccount() {
        return account;
    }

    public void setAccount(Account account) {
        this.account = account;
    }

    public String getPlayerId() {
        return playerId;
    }

    public void setPlayerId(String playerId) {
        this.playerId = playerId;
    }

    public String getPlayerName() {
        return playerName;
    }

    public void setPlayerName(String playerName) {
        this.playerName = playerName;
    }

    public GamePlay getPreviousGame() {
        return previousGame;
    }

    public void setPreviousGame(GamePlay previousGame) {
        this.previousGame = previousGame;
    }



    public Player() {

    }
    public Player(Account account, String playerName, String playerId) {
        this.account = account;
        this.playerName = playerName;
        this.playerId = playerId;
        this.previousGame = null;
    }
    public Player(Account account, String playerName, String playerId, GamePlay previousGame) {
        this.account = account;
        this.playerName = playerName;
        this.playerId = playerId;
        this.previousGame = previousGame;
    }

    @Override
    public String toString() {
        return playerName;
    }

    public static void login(String email,String password, final ProcessListener listener) {

            PlayerAccountDB.verifyCredentials(email, password, new PlayerAccountDB.VerifyCredentialsListener() {
                @Override
                public void onVerifySuccess(Account existingAccount) {
                        PlayerAccountDB.queryPlayer(existingAccount, new PlayerAccountDB.QueryPlayerListener() {
                            @Override
                            public void onQueryPlayerSuccess(Player existingPlayer) {
                                listener.onProcessSuccess(existingPlayer);
                            }
                            @Override
                            public void onQueryPlayerFailed(String message) {
                                listener.onProcessFailed(message);
                            }
                        });
                    }

                @Override
                public void onVerifyFailed(String message) {
                    listener.onProcessFailed(message);
                }
            });
        }

    public static void register(String email, String password, String playerName, final ProcessListener listener) {
        PlayerAccountDB.queryAccount(email, new PlayerAccountDB.QueryAccountListener() {
            @Override
            public void onQueryAccountSuccess(Account existingAccount) {
                    listener.onProcessFailed("This account already exist");
            }
            @Override
            public void onQueryAccountFailed(String message) {
                PlayerAccountDB.createAccount(email, password, new PlayerAccountDB.CreationAccountListener() {
                    @Override
                    public void onCreationSuccess(Account account) {
                        PlayerAccountDB.createPlayer(account, playerName, new PlayerAccountDB.CreationPlayerListener() {
                            @Override
                            public void onCreationSuccess(Player player) {
                                listener.onProcessSuccess(player);
                            }
                            @Override
                            public void onCreationFailed(String message) {
                                listener.onProcessFailed(message);
                            }
                        });
                    }
                    @Override
                    public void onCreationFailed(String message) {
                        listener.onProcessFailed(message);
                    }
                });
            }
        });
    }

    public static Player loginAsGuest() {
        Player newGuest = new Player(null, "Guest", null);
        return newGuest;
    }
    public interface  SignOutListener {
        void onSignOutProcess();
    }
    public static void logout(final SignOutListener listener) {
        listener.onSignOutProcess();
    }
    public static  void exit(final SignOutListener listener) {
        listener.onSignOutProcess();
    }

    public interface GetSessionAccountListener {
        void onGetSessionAccountSuccess(Player existingPlayer);
        void onGetSessionAccountFailed(String message);
    }
    public static void getSessionAccount(String email, GetSessionAccountListener listener) {
        PlayerAccountDB.queryAccount(email, new PlayerAccountDB.QueryAccountListener() {
            @Override
            public void onQueryAccountSuccess(Account existingAccount) {
                PlayerAccountDB.queryPlayer(existingAccount, new PlayerAccountDB.QueryPlayerListener() {
                    @Override
                    public void onQueryPlayerSuccess(Player existingPlayer) {
                        listener.onGetSessionAccountSuccess(existingPlayer);
                    }

                    @Override
                    public void onQueryPlayerFailed(String message) {
                        listener.onGetSessionAccountFailed(message);
                    }
                });
            }
            @Override
            public void onQueryAccountFailed(String message) {
                listener.onGetSessionAccountFailed(message);
            }
        });
    }
}
