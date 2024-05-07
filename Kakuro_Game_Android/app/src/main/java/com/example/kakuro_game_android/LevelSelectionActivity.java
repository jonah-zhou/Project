package com.example.kakuro_game_android;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;

import model.Level;
import data.LevelAdapter;
import model.Player;

public class LevelSelectionActivity extends AppCompatActivity {
    ListView listViewLevel;
    ArrayList<Level> levelList;
    Player playerLogin;
    LevelAdapter adapter;
    ImageButton btnReturn;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_level_selection);
        initialize();
    }
    private void redirectToMenuPage() {
        Intent intent = new Intent(LevelSelectionActivity.this, GameMenuActivity.class);
        startActivity(intent);
        finish();
    }
    private void initialize() {
        playerLogin = (Player) getIntent().getSerializableExtra("playerLogin");
        listViewLevel = findViewById(R.id.listViewLevel);
        btnReturn = findViewById(R.id.btnReturn);
        btnReturn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                redirectToMenuPage();
            }
        });
        Level.getListLevel(new Level.QueryAllLevelListener() {
            @Override
            public void onQueryAllLevelSuccess(ArrayList<Level> listOfLevels) {
                adapter = new LevelAdapter(getApplicationContext(), listOfLevels);
                listViewLevel.setAdapter(adapter);
                adapter.notifyDataSetChanged();
            }
            @Override
            public void onQueryAllLevelFailed(String message) {
                displayMessage("Error");
            }
        });
    }
    private void displayMessage(String message) {
        Toast.makeText(LevelSelectionActivity.this, message, Toast.LENGTH_SHORT).show();
    }
}