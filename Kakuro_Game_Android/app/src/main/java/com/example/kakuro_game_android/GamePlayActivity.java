package com.example.kakuro_game_android;

import static android.content.ContentValues.TAG;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.Typeface;
import android.os.Bundle;
import android.util.Log;
import android.util.TypedValue;
import android.view.Gravity;
import android.view.View;
import android.widget.Button;
import android.widget.GridLayout;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;

import java.util.List;

import data.CellTag;
import data.DiagonalSumCellView;
import data.PlayerAccountDB;
import data.RecordDB;
import model.Account;
import model.GamePlay;
import model.Grid;
import model.Level;
import model.Player;



public class GamePlayActivity extends AppCompatActivity implements View.OnClickListener {
    Player playerLogin;
    GamePlay currentGamePlay;
    Button btnRemove, btnCheck, btnHint, btnSave, btnSubmit, btnClearAll;
    private View previousCell = null;
    TextView tvMistake, tvHintCount;
    ImageButton btnReturn;
    private int countMistake = 0;
    private Grid kakuroGrid;
    private GridLayout gridLayout;
    private int hintCount = 3;
    private static final String TAG_DEFINITIVE = "Definitive";
    private static final String TAG_NOTE = "Note";
    private static final String TAG_INPUT = "input";
    ProgressDialog progressDialog;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_game_play);
        initialize();
    }
    private void initialize() {

        btnRemove = findViewById(R.id.btnRemove);
        btnRemove.setOnClickListener(this);

        btnCheck = findViewById(R.id.btnCheck);
        btnCheck.setOnClickListener(this);

        btnSubmit = findViewById(R.id.btnSubmit);
        btnSubmit.setOnClickListener(this);

        btnSave = findViewById(R.id.btnSave);
        btnSave.setOnClickListener(this);

        btnHint = findViewById(R.id.btnHint);
        btnHint.setOnClickListener(this);

        btnClearAll = findViewById(R.id.btnClearAll);
        btnClearAll.setOnClickListener(this);

        tvMistake = findViewById(R.id.tvMistake);
        tvMistake.setText(String.valueOf(countMistake));

        tvHintCount = findViewById(R.id.tvHintCount);


        btnReturn = findViewById(R.id.btnReturn);
        btnReturn.setOnClickListener(this);

        gridLayout = findViewById(R.id.kakuroGrid);
        currentGamePlay = (GamePlay) getIntent().getSerializableExtra("gamePlay");
        kakuroGrid = currentGamePlay.getLevel().getGrid();

        if (currentGamePlay.getPlayerAnswer() != null) {
            generatePuzzleGrid(currentGamePlay.getPlayerAnswer());
            hintCount = currentGamePlay.getHint();
        }
        else {
            generatePuzzleGrid(kakuroGrid.getDatas());
        }
        tvHintCount.setText(String.valueOf(hintCount));
        setupNumberSelection();
        updateHintButtonState();
        FirebaseAuth mAuth = FirebaseAuth.getInstance();
        FirebaseUser currentUser = mAuth.getCurrentUser();
        if (currentUser != null) {
            Player.getSessionAccount(currentUser.getEmail(), new Player.GetSessionAccountListener() {
                @Override
                public void onGetSessionAccountSuccess(Player existingPlayer) {
                    playerLogin = existingPlayer;
                    getMistakeFromDatabase(currentGamePlay.getLevel(), playerLogin.getPlayerId());
                    btnSave.setVisibility(View.VISIBLE);
                }

                @Override
                public void onGetSessionAccountFailed(String message) {
                    displayMessage(message);
                }
            });
        }
        else {
            playerLogin = new Player();
            playerLogin.setAccount(null);
            tvMistake.setText("0");
            disableSaveButton();
        }
    }
    private void disableSaveButton() {
        btnSave.setVisibility(View.GONE);
    }
    private void updateHintButtonState() {
        if (hintCount == 0) {
            btnHint.setEnabled(false);
            btnHint.setBackgroundColor(Color.GRAY);
        }
        else {
            btnHint.setEnabled(true);
            btnHint.setBackgroundResource(R.drawable.button_shape);
        }
    }
    private void updateHint() {
        hintCount--;
        tvHintCount.setText(String.valueOf(hintCount));
        updateHintButtonState();
    }
    private void generatePuzzleGrid(String data) {

        String[] rows = data.split(";");


        for (int i = 0; i < rows.length; i++) {
            String[] cells = rows[i].split(",");

            for (int j = 0; j < cells.length; j++) {
                GridLayout.LayoutParams params = new GridLayout.LayoutParams();
                params.width = 0;
                params.height = 0;
                params.rowSpec = GridLayout.spec(i, 1f); // row number
                params.columnSpec = GridLayout.spec(j, 1f); //column number
                params.setMargins(1, 1, 1, 1); // For cell borders
                String cellData = cells[j];
                if (cellData.equals("#")) {
                    // Null cell
                    TextView cellView = new TextView(this);
                    cellView.setLayoutParams(params);
                    cellView.setBackgroundResource(R.drawable.null_cell_background);
                    gridLayout.addView(cellView);
                } else if (cellData.contains(".")) {
                    // Sum cell, extract and set the sums
                    String[] parts = cellData.split("\\.");
                    String vSum = parts[0].equals("vSum") ? "" : parts[0];
                    String hSum = parts[1].equals("hSum") ? "" : parts[1];

                    DiagonalSumCellView sumCellView = new DiagonalSumCellView(this, hSum, vSum);

                    sumCellView.setBackgroundResource(R.drawable.null_cell_background);
                    sumCellView.setLayoutParams(params);
                    gridLayout.addView(sumCellView);
                } else if (cellData.equals("_")) {
                    // Empty cell
                    TextView cellView = new TextView(this);
                    cellView.setLayoutParams(params);
                    cellView.setBackgroundResource(R.drawable.cell_background);
                    cellView.setGravity(Gravity.CENTER);
                    cellView.setTextSize(TypedValue.COMPLEX_UNIT_SP, 18);
                    cellView.setTypeface(null, Typeface.BOLD);
                    cellView.setTextColor(Color.BLACK);
                    cellView.setOnClickListener(this);

                    CellTag cellTag = new CellTag(R.drawable.cell_background, TAG_INPUT);
                    cellView.setTag(cellTag);
//                    cellView.setTag(R.drawable.cell_background); // Use tag to store the original background for easy reset
                    gridLayout.addView(cellView);
                }
                else {
                    TextView cellView = new TextView(this);
                    cellView.setLayoutParams(params);
                    cellView.setBackgroundResource(R.drawable.cell_background);
                    cellView.setGravity(Gravity.CENTER);
                    cellView.setTextSize(TypedValue.COMPLEX_UNIT_SP, 18);
                    cellView.setTypeface(null, Typeface.BOLD);
                    cellView.setTextColor(Color.BLACK);
                    cellView.setText(cellData);
                    cellView.setOnClickListener(this);
                    CellTag cellTag = new CellTag(R.drawable.cell_background, TAG_DEFINITIVE);
                    cellView.setTag(cellTag);
                    gridLayout.addView(cellView);
                }
            }
        }
    }
    // #,11.hSum,24.hSum,#,#;vSum.16,_,_,17.hSum,#;vSum.13,_,_,_,17.hSum;#,vSum.24,_,_,_;#,#,vSum.16,_,_;
    // #,#,32.hSum,14.hSum,#,34.hSum,3.hSum;#,3.9,_,_,5.3,_,_;vSum.28,_,_,_,_,_,_;vSum.10,_,_,15.10,_,_,14.hSum;#,16.7,_,_,13.13,_,_;vSum.39,_,_,_,_,_,_;vSum.14,_,_,vSum.16,_,_,#;
    // #,17.hSum,10.hSum,22.hSum,#,28.hSum,5.hSum,23.hSum,18.hSum,#;vSum.23,_,_,_,vSum.15,_,_,_,_,4.hSum;vSum.18,_,_,_,20.20,_,_,_,_,_;#,17.hSum,33.23,_,_,_,27.19,_,_,_;vSum.4,_,_,19.23,_,_,_,25.hSum,10.hSum,9.hSum;vSum.45,_,_,_,_,_,_,_,_,_;vSum.28,_,_,_,_,9.24,_,_,_,_;#,8.17,_,_,12.13,_,_,_,6.hSum,16.hSum;vSum.3,_,_,vSum.8,_,_,vSum.11,_,_,_;vSum.16,_,_,vSum.7,_,_,vSum.21,_,_,_;
    private void fillNumber(int number, String tagType) {
        if (previousCell != null && previousCell instanceof TextView) {
            TextView previousTextView = (TextView) previousCell;

            // Retrieve the current tag to update it
            CellTag cellTag = (CellTag) previousTextView.getTag();
            // Update the existing tag's type
            cellTag.setCellType(tagType);


            // Apply the updated tag to the TextView
            previousTextView.setTag(cellTag);

            // Set text color and background based on the type
            if (TAG_NOTE.equals(tagType)) {
                previousTextView.setTextColor(Color.GRAY);
                previousTextView.setBackgroundColor(Color.LTGRAY);
            } else if (TAG_DEFINITIVE.equals(tagType)) {
                previousTextView.setTextColor(Color.BLACK); // Reset to default color
                previousTextView.setBackgroundColor(Color.WHITE); // Reset to default background
            }

            // Set the number in the TextView
            previousTextView.setText(String.valueOf(number));
        } else {
            Toast.makeText(this, "Please select a cell to fill.", Toast.LENGTH_SHORT).show();
        }
    }
    @Override
    public void onClick(View v) {
        if (v.getTag() instanceof CellTag) {
            View selectedCellView = v;
            highlightCell(selectedCellView);
        }
        else if(v.getTag() instanceof String) {
            String tag = (String) v.getTag();
            if (TAG_DEFINITIVE.equals(tag)) {
                int num = Integer.parseInt(((TextView)v).getText().toString());
                fillNumber(num,tag);
            }
            else if (TAG_NOTE.equals(tag)) {
                int num = Integer.parseInt(((TextView) v).getText().toString());
                makeNote(num);
            }
        } else {
            // Non-tagged views: buttons and other UI elements
            if (v.getId() == R.id.btnRemove) {
                removeNumber();
            }
            else if (v.getId() == R.id.btnClearAll){
                clearAll();
            }
            else if (v.getId() == R.id.btnCheck){
                String playerAnswer = savePlayerAnswer(gridLayout);
                GamePlay.checkAnswer(currentGamePlay, playerAnswer, playerLogin, new GamePlay.CheckGameListener() {
                    @Override
                    public void onCheckGameSuccess(List<Integer> mistake) {
                        if (mistake.size() > 0) {
                            highlightIncorrectAnswer(mistake);
                        }

                    }
                    @Override
                    public void onCheckGameFailed(String message) {
                        displayMessage(message);
                    }
                });
            }
            else if (v.getId() == R.id.btnSubmit){
                String playerAnswer = savePlayerAnswer(gridLayout);;
                if (isFillAllCell(playerAnswer)) {
                    GamePlay.submit(currentGamePlay, playerAnswer, playerLogin, new GamePlay.SubmitGameListener() {
                        @Override
                        public void onSubmitGameSuccess(List<Integer> mistake) {
                            if (mistake.size() > 0) {
                                highlightIncorrectAnswer(mistake);
                                displayDialogSubmitMessage();
                            }

                        }
                        @Override
                        public void onSubmitGameFailed(String message) {
                            displayMessage(message);
                        }
                    });
                }
                else {
                   displayMessage("Please fill up all cell");
                }
            }
            else if (v.getId() == R.id.btnHint){
                    if (previousCell != null && previousCell.getTag() instanceof CellTag) {
                        if (hintCount > 0) {
                            View selectedCellView = previousCell;
                            setUpHint();
                            GamePlay.showHint(selectedCellView, gridLayout, currentGamePlay);
                            updateHint();
                            if (hintCount == 0) {
                                displayMessage("You've used all hints");
                                disableHintButton();
                            }
                        }
                    } else {
                        displayMessage("Please select a cell to show the answer");
                    }

            }
            else if(v.getId() == R.id.btnSave) {
                setUpSaveGame();
                GamePlay.saveGame(currentGamePlay, playerLogin, new GamePlay.SaveGameListener() {
                    @Override
                    public void onSaveGameSuccess() {
                        // Update successful
                        Log.d(TAG, "saveGame: Update previous game success.");
                        displayMessage("Game Saved");
                        progressDialog.dismiss();
                        Log.d(TAG, "saveGame: Progress dialog dismissed.");
                    }

                    @Override
                    public void onSaveGameFailed(String message) {
                        // Update failed
                        Log.d(TAG, "saveGame: Update previous game failed: " + message);
                        displayMessage(message);
                        progressDialog.dismiss();
                        Log.d(TAG, "saveGame: Progress dialog dismissed.");
                    }
                });

            }
            else if(v.getId() == R.id.btnReturn) {
                if (playerLogin.getAccount() != null) {
                    returnToPreviousMenu();
                }
                else {
                    redirectMenuPage();
                }
            }
            else{
                if (previousCell != null) {
                    highlightCell(previousCell);  // Maintain highlight if no new cell is selected
                }
            }
        }
    }

    private void makeNote(int num) {
        fillNumber(num, TAG_NOTE);
    }

    private void disableHintButton() {
        updateHintButtonState();
    }

    private void setUpSaveGame() {
        // Initialize progress dialog
        progressDialog = progressionDialogInitialize("Saving game ...");
        currentGamePlay.setHint(Integer.valueOf(tvHintCount.getText().toString()));
        String playerAnswer = savePlayerAnswer(gridLayout);
        currentGamePlay.setPlayerAnswer(playerAnswer);
        // Show progress dialog
        progressDialog.show();
    }

    private void setUpHint() {
        // to set the tag of definitive on the cell
        TextView previousTextView = (TextView) previousCell;
        CellTag cellTag = (CellTag) previousTextView.getTag();
        cellTag.setCellType("Definitive");
        previousTextView.setTag(cellTag);

        previousTextView.setTextColor(Color.BLACK); // Reset to default color
        previousTextView.setBackgroundColor(Color.WHITE); // Reset to default background
    }
    private void returnToPreviousMenu() {
        android.app.AlertDialog.Builder builder = new android.app.AlertDialog.Builder(this);
        builder.setMessage("Do you want to save game before exiting the current gameplay?");
        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                ProgressDialog progressDialog = progressionDialogInitialize("Saving game ...");

                GridLayout gridLayout = findViewById(R.id.kakuroGrid);
                String playerAnswer = savePlayerAnswer(gridLayout);
                currentGamePlay.setPlayerAnswer(playerAnswer);
                currentGamePlay.setHint(Integer.valueOf(tvHintCount.getText().toString()));
                playerLogin.setPreviousGame(currentGamePlay);
                // Show progress dialog
                progressDialog.show();
                // Update previous game in Firestore
                GamePlay.saveGame(currentGamePlay, playerLogin, new GamePlay.SaveGameListener() {
                    @Override
                    public void onSaveGameSuccess() {
                        // Update successful
                        Log.d(TAG, "saveGame: Update previous game success.");
                        displayMessage("Game Saved");
                        progressDialog.dismiss();
                        Log.d(TAG, "saveGame: Progress dialog dismissed.");

                        redirectMenuPage();
                    }

                    @Override
                    public void onSaveGameFailed(String message) {
                        // Update failed
                        Log.d(TAG, "saveGame: Update previous game failed: " + message);
                        displayMessage(message);
                        progressDialog.dismiss();
                        Log.d(TAG, "saveGame: Progress dialog dismissed.");
                        redirectMenuPage();
                    }
                });

            }
        });
        builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                redirectMenuPage();
            }
        });
        builder.setNeutralButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                // Stay on the current page
                dialog.dismiss();
            }
        });
        android.app.AlertDialog dialog = builder.create();
        dialog.show();

    }
    private ProgressDialog progressionDialogInitialize(String message) {
        ProgressDialog progressDialog = new ProgressDialog(this);
        progressDialog.setTitle(message);
        progressDialog.show();
        return progressDialog;
    }
    private boolean isFillAllCell(String playerAnswer) {
        return  !playerAnswer.contains("_");
    }
    private void displayDialogSubmitMessage(){
        AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
        alertDialog.setMessage("You finish the game level " + currentGamePlay.getLevel().getLevelId() +". Your total mistake is: " + countMistake + "\nDo you want to exit the gameplay?");
        alertDialog.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                redirectMenuPage();
            }
        }).setNegativeButton("No", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {

            }
        });
        alertDialog.create().show();
    }
    private void redirectMenuPage() {
        Intent intent = new Intent(this, GameMenuActivity.class);

        intent.putExtra("playerLogin", playerLogin);
        startActivity(intent);
        finish();
    }
    private void highlightIncorrectAnswer(List<Integer> mistake) {
        for (int i = 0; i < gridLayout.getChildCount(); i++) {
            View childView = gridLayout.getChildAt(i);
            if (childView instanceof TextView && childView.getTag() instanceof Integer) {
                TextView textView = (TextView) childView;
                textView.setBackgroundResource((Integer) textView.getTag());
            }
        }

        if(mistake.isEmpty()){
            displayMessage("All filled cells are correct!");
        }else{for (int index : mistake) {
            View childView = gridLayout.getChildAt(index);
            if (childView instanceof TextView) {
                TextView textView = (TextView) childView;
                textView.setBackgroundColor(Color.RED);
                textView.setTag(R.id.incorrect, true);
                countMistake++;
            }
        }}
        tvMistake.setText(String.valueOf(countMistake));
    }
    private void displayMessage(String message) {
        Toast.makeText(GamePlayActivity.this, message, Toast.LENGTH_SHORT).show();
    }

    private void getMistakeFromDatabase(Level level, String playerId) {
        RecordDB.getMistake(level, playerId, new RecordDB.GetMistakeListener() {
            @Override
            public void onGetMistakeSuccess(Integer playerMistake) {
                tvMistake.setText(String.valueOf(playerMistake));
            }

            @Override
            public void onGetMistakeFailed(String message) {
                Log.e("RecordDB", "Failed to get mistake: " + message);
            }
        });
    }
    private void clearAll() {
//        hintCount = 3;
        tvHintCount.setText(String.valueOf(hintCount));
        updateHintButtonState();
        clearPreviousCellHighlight();

        int childCount = gridLayout.getChildCount();
        for (int i = 0; i < childCount; i++) {
            View childView = gridLayout.getChildAt(i);
            if (childView instanceof TextView) {
                ((TextView) childView).setText(null);
            }
        }
    }
    private void clearPreviousCellHighlight() {
        if (previousCell != null && previousCell.getTag() instanceof Integer) {
            int backgroundResource = (Integer) previousCell.getTag();
            previousCell.setBackgroundResource(backgroundResource);
            previousCell = null; // Clear the reference to the previous cell
        }
    }

    private void highlightCell(View cellView) {
        if (cellView.getTag() instanceof CellTag) {
            // Re-highlighting previous cell with its original background if it's different from the current
            if (previousCell != null && previousCell != cellView) {
                if (previousCell.getTag() instanceof CellTag) {
                    CellTag previousTag = (CellTag) previousCell.getTag();
                    previousCell.setBackgroundResource(previousTag.getBackgroundResource());
                }
            }

            // Clearing previous incorrect highlights
            for (int i = 0; i < gridLayout.getChildCount(); i++) {
                View child = gridLayout.getChildAt(i);
                if (child instanceof TextView) {
                    Object tag = child.getTag();
                    if (tag instanceof CellTag) {
                        child.setBackgroundResource(((CellTag) tag).getBackgroundResource());
                        child.setTag(tag); // Reset the original tag
                    }
                }
            }

            cellView.setBackgroundColor(Color.GREEN);
            previousCell = cellView;  // Update the previousCell reference
        } else {
            // Handle other cases or log an error if expected tag is not found
            Log.e("highlightCell", "Tag is not a CellTag");
        }
    }

    private String savePlayerAnswer(GridLayout grid) {
/*        StringBuilder playerAnswerBuilder = new StringBuilder();
        int childCount = grid.getChildCount();

        for (int i = 0; i < childCount; i++) {
            View childView = grid.getChildAt(i);
            if (childView instanceof TextView) {
                TextView textView = (TextView) childView;
                String cellData = textView.getText().toString().trim();
                CellTag tag = (CellTag) textView.getTag();
                // Check if the cell contains a definitive answer
                if (!cellData.isEmpty() && TAG_DEFINITIVE.equals(tag.getCellType())) {
                    playerAnswerBuilder.append(cellData);
                } else {
                    playerAnswerBuilder.append("_");
                }
            }
            // Add semicolons or commas as appropriate
            if ((i + 1) % grid.getColumnCount() == 0) {
                playerAnswerBuilder.append(";");
            } else {
                playerAnswerBuilder.append(",");
            }
        }
        return playerAnswerBuilder.toString();*/
        StringBuilder gridString = new StringBuilder();

        int rows = kakuroGrid.getRows();
        int columns = kakuroGrid.getColumns();
        for (int i = 0; i < rows; i++) {
            StringBuilder rowString = new StringBuilder();

            for (int j = 0; j < columns; j++) {
                View cell = grid.getChildAt(i * columns + j);

                // Check the type of the cell and append the appropriate string
                if (cell instanceof TextView) {

                    TextView textView = (TextView) cell;
                    String cellText = textView.getText().toString();
                    CellTag cellTag = (CellTag) cell.getTag();

                    if (cellTag != null) {
                        Log.d("Truong", cellTag.getCellType());
                        if (TAG_DEFINITIVE.equals(cellTag.getCellType())) {
                            rowString.append(cellText); // Pre-filled number cell
                            Log.d("Truong", cellText);
                            Log.d("Truong", rowString.toString());
                        } else if (cellTag.getCellType().equals("input") || cellTag.getCellType().equals("Note")) {
                            rowString.append("_"); // Editable empty cell
                        }
                    }else {
                        rowString.append("#"); // Null cell
                    }
                }
                else if (cell instanceof DiagonalSumCellView) {
                    DiagonalSumCellView sumCellView = (DiagonalSumCellView) cell;
                    String vSum = sumCellView.getHorizontalSum();
                    String hSum = sumCellView.getVerticalSum();

                    vSum = vSum.isEmpty() ? "" : vSum;
                    hSum = hSum.isEmpty() ? "" : hSum;

                    // Based on your convention: "left of dot is vSum, right is hSum"
                    if (vSum.isEmpty() && !hSum.isEmpty()) {
                        rowString.append("vSum.").append(hSum);
                    } else if (!vSum.isEmpty() && hSum.isEmpty()) {
                        rowString.append(vSum).append(".hSum");
                    } else if (!vSum.isEmpty() && !hSum.isEmpty()) {
                        rowString.append(vSum).append(".").append(hSum);
                    }

                }

                // Append comma if not the last cell in the row
                if (j < columns - 1) {
                    rowString.append(",");
                }
            }

            // Append the row string to the grid string
            gridString.append(rowString.toString());

            // Append semicolon if not the last row
            if (i < rows - 1) {
                gridString.append(";");
            }
        }
        return gridString.toString();
    }
    /*private String getPlayerAnswerFromGrid() {
        StringBuilder playerAnswerBuilder = new StringBuilder();
        GridLayout gridLayout = findViewById(R.id.kakuroGrid);
        int childCount = gridLayout.getChildCount();

        for (int i = 0; i < childCount; i++) {
            View childView = gridLayout.getChildAt(i);
            if (childView instanceof TextView) {
                TextView textView = (TextView) childView;
                String cellData = textView.getText().toString().trim();
                CellTag tag = (CellTag) textView.getTag();
                // Check if the cell contains a definitive answer
                if (!cellData.isEmpty() && TAG_DEFINITIVE.equals(tag.getCellType())) {
                    playerAnswerBuilder.append(cellData);
                } else {
                    playerAnswerBuilder.append("_");
                }
            }
            // Add semicolons or commas as appropriate
            if ((i + 1) % gridLayout.getColumnCount() == 0) {
                playerAnswerBuilder.append(";");
            } else {
                playerAnswerBuilder.append(",");
            }
        }

        return playerAnswerBuilder.toString();
    }*/

    /*private void fillNumber(int number) {
        if (previousCell != null && previousCell.getTag() instanceof Integer) { // Again, checking if it's a cell in the grid
            ((TextView) previousCell).setText(String.valueOf(number));
        } else {
            Toast.makeText(this, "Please select a cell to fill.", Toast.LENGTH_SHORT).show();
        }
    }*/

    private void setupNumberSelection() {
        int[] numberIds = {R.id.tv1, R.id.tv2, R.id.tv3, R.id.tv4, R.id.tv5, R.id.tv6, R.id.tv7, R.id.tv8, R.id.tv9};
        int[] noteIds = {R.id.tvNotes1, R.id.tvNotes2, R.id.tvNotes3, R.id.tvNotes4, R.id.tvNotes5, R.id.tvNotes6, R.id.tvNotes7, R.id.tvNotes8, R.id.tvNotes9};

        for (int id : numberIds) {
            TextView numberView = findViewById(id);
            numberView.setOnClickListener(this);
            numberView.setTag(TAG_DEFINITIVE);  // Set tag for definitive numbers
        }

        for (int id : noteIds) {
            TextView noteView = findViewById(id);
            noteView.setOnClickListener(this);
            noteView.setTag(TAG_NOTE);  // Set tag for note numbers
        }
    }
    private void removeNumber() {
        if (previousCell != null && previousCell.getTag() instanceof CellTag) { // Again, checking if it's a cell in the grid
            ((TextView) previousCell).setText(null);
        } else {
            Toast.makeText(this, "Please select a cell to remove.", Toast.LENGTH_SHORT).show();
        }
    }
}