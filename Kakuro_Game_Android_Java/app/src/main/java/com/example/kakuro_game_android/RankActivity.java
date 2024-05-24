package com.example.kakuro_game_android;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

import data.RankAdapter;
import model.Player;
import model.Record;

public class RankActivity extends AppCompatActivity {
    int receivedLevelId;
    ListView listViewRank;
    RankAdapter rankAdapter;
    ImageButton btnReturn;
    ArrayList<Player> topPlayers;
    TextView txtTitleRank;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_rank);
        initialize();
    }
    private ProgressDialog progressionDialogInitialize(String message) {
        ProgressDialog progressDialog = new ProgressDialog(this);
        progressDialog.setTitle(message);
        progressDialog.show();
        return progressDialog;
    }
    private void redirectLevelPage() {
        Intent intent = new Intent(RankActivity.this, LevelSelectionActivity.class);
        startActivity(intent);
        finish();
    }
    private void initialize() {
        receivedLevelId = getIntent().getIntExtra("receivedLevelId", 0);
        listViewRank = findViewById(R.id.listViewRank);
        txtTitleRank = findViewById(R.id.txtTitleRank);
        txtTitleRank.setText("LEVEL " + receivedLevelId);
        btnReturn = findViewById(R.id.btnReturn);
        btnReturn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                redirectLevelPage();
            }
        });
        ProgressDialog progressDialog = progressionDialogInitialize("Generating Rank ...");
        Record.getRankByLevel(receivedLevelId, new Record.GetRankListener() {
            @Override
            public void onGetRankSuccess(ArrayList<Record> rank) {
                rankAdapter= new RankAdapter(RankActivity.this, rank);
                listViewRank.setAdapter(rankAdapter);
                progressDialog.dismiss();
            }

            @Override
            public void onGetRankFailed(String message) {
                displayMessage(message);
            }
        });
    }
    private void displayMessage(String message) {
        Toast.makeText(RankActivity.this, message, Toast.LENGTH_LONG).show();
    }
}