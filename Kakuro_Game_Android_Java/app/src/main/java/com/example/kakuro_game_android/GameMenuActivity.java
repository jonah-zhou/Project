package com.example.kakuro_game_android;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;

import data.PlayerAccountDB;
import data.RecordDB;
import model.Account;
import model.GamePlay;
import model.Player;
import model.Record;

public class GameMenuActivity extends AppCompatActivity implements View.OnClickListener {
    Player playerLogin;
    Button btnNewGame, btnPreviousGame, btnTutorial, btnLogOut, btnExit;
    ImageButton btnReturn;
    AlertDialog.Builder alertDialog;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_game_menu);
        initialize();
    }
    private void initialize() {
        btnReturn = findViewById(R.id.btnReturn);
        btnReturn.setOnClickListener(this);
        btnNewGame = findViewById(R.id.btnNewGame);
        btnPreviousGame = findViewById(R.id.btnPreviousGame);
        btnTutorial = findViewById(R.id.btnTutorial);
        btnLogOut = findViewById(R.id.btnLogOut);
        btnExit = findViewById(R.id.btnExit);
        btnNewGame.setOnClickListener(this);
        btnPreviousGame.setOnClickListener(this);
        btnTutorial.setOnClickListener(this);
        btnLogOut.setOnClickListener(this);
        btnExit.setOnClickListener(this);
        FirebaseAuth mAuth = FirebaseAuth.getInstance();
        FirebaseUser currentUser = mAuth.getCurrentUser();
        if (currentUser != null) {
            btnReturn.setVisibility(View.GONE);
            Player.getSessionAccount(currentUser.getEmail(), new Player.GetSessionAccountListener() {
                @Override
                public void onGetSessionAccountSuccess(Player existingPlayer) {
                    playerLogin = existingPlayer;
                    if (playerLogin.getPreviousGame() == null) {
                        btnPreviousGame.setVisibility(View.GONE);

                    }
                }
                @Override
                public void onGetSessionAccountFailed(String message) {
                    displayMessage(message);
                }
            });
        }
        else {
            btnLogOut.setVisibility(View.GONE);
            btnPreviousGame.setVisibility(View.GONE);
            btnReturn.setVisibility(View.VISIBLE);
        }
    }

    @Override
    public void onClick(View v) {
        if (v.getId() == R.id.btnTutorial) {
            Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse("https://youtu.be/BYX93SLkNrQ"));
            startActivity(intent);
        }
        else if (v.getId() == R.id.btnNewGame) {
          redirectToLevelPage();
        }
        else if (v.getId() == R.id.btnPreviousGame) {
            GamePlay previousGame = GamePlay.continuePreviousGame(playerLogin);
            redirectToGamePlay(previousGame);
        }
        else if (v.getId() == R.id.btnLogOut) {
            Player.logout(new Player.SignOutListener() {
                @Override
                public void onSignOutProcess() {
                    endSession = true;
                    displayOptionMessage("Do you want to logout?");

                }
            });
        }
        else if (v.getId() == R.id.btnExit) {
            Player.exit(new Player.SignOutListener() {
                @Override
                public void onSignOutProcess() {
                    endSession = false;
                    displayOptionMessage("Do you want to exit app?");

                }
            });
        }
        else if (v.getId() == R.id.btnReturn) {
            redirectToLoginPage();
        }
    }
    private void redirectToGamePlay(GamePlay gamePlay) {
        Intent intent = new Intent(this, GamePlayActivity.class);
        intent.putExtra("gamePlay", gamePlay);
        startActivity(intent);
    }

    boolean endSession = false;
    private void redirectToLevelPage() {
        Intent intent = new Intent(GameMenuActivity.this, LevelSelectionActivity.class);
        intent.putExtra("playerLogin", playerLogin);
        startActivity(intent);
    }
    public void displayOptionMessage(String message) {
        AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
        alertDialog.setMessage(message);
        alertDialog.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                if (endSession) {
                    FirebaseAuth mAuth = FirebaseAuth.getInstance();
                    mAuth.signOut();
                    displayMessage("Logout Successfully");
                    redirectToLoginPage();
                }
                else {
                    displayMessage("Exit Application Successfully");
                    System.exit(0);
                }
            }
        }).setNegativeButton("No", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {

            }
        });
        alertDialog.create().show();
    }
    private void displayMessage(String message) {
        Toast.makeText(GameMenuActivity.this, message, Toast.LENGTH_SHORT).show();
    }
    private void redirectToLoginPage() {
        Intent intent = new Intent(GameMenuActivity.this, LoginActivity.class);
        startActivity(intent);
        finish();
    }
}