package com.example.kakuro_game_android;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;

import model.Player;

public class RegistrationActivity extends AppCompatActivity implements View.OnClickListener {

    EditText edTextEmail, edTextPassword, edTextPlayerName;
    Button btnRegister;

    FirebaseAuth mAuth;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registration);
        initialize();
    }

    private void initialize() {
        edTextEmail = findViewById(R.id.edEmail);
        edTextPassword = findViewById(R.id.edPassword);
        edTextPlayerName = findViewById(R.id.edPlayerName);
        btnRegister = findViewById(R.id.btnRegister);
        mAuth = FirebaseAuth.getInstance();
        btnRegister.setOnClickListener(this);
    }

    @Override
    public void onClick(View v) {
        if (v.getId() == R.id.btnRegister) {

            String email = String.valueOf(edTextEmail.getText());
            String password = String.valueOf(edTextPassword.getText());
            String playerName = String.valueOf(edTextPlayerName.getText());

            boolean isValid = verifyInput(email, password, playerName);
            if (isValid) {
                ProgressDialog progressDialog = progressionDialogInitialize("Register Account is in process ...");
                Player.register(email, password, playerName, new Player.ProcessListener() {
                    @Override
                    public void onProcessSuccess(Player player) {
                        progressDialog.dismiss();
                        displayMessage("Register Successfully");
                        redirectLoginPage();
                    }
                    @Override
                    public void onProcessFailed(String message) {
                        progressDialog.dismiss();
                        displayMessage(message);
                    }
                });
            }
            else {
                displayMessage("Account Information Input is incorrect");
            }
        }
    }

    private boolean verifyInput(String email, String password, String playerName) {
        if (TextUtils.isEmpty(playerName)) {
            displayMessage("Enter Player Name");
            return false;
        }

        if(TextUtils.isEmpty(email)){
            displayMessage("Enter Email");
            return false;
        }

        if(TextUtils.isEmpty(password)){
            displayMessage("Enter Password");
            return false;
        }
        if (!email.matches("^[\\w.+\\-]+@gmail\\.com$")) {
            displayMessage("Email input is wrong");
            return false;
        }
        if (!playerName.matches("^\\w{6,8}$")) {
            displayMessage("Player Name must between 6 to 8 characters");
            return false;
        }
        if (!password.matches("^\\w{8,16}$")) {
            displayMessage("Password must between 8 to 16 characters");
            return false;
        }
        return true;
    }
    private void displayMessage(String message) {
        Toast.makeText(RegistrationActivity.this, message, Toast.LENGTH_LONG).show();
    }
    private void redirectLoginPage() {
        Intent intent = new Intent(getApplicationContext(), LoginActivity.class);
        startActivity(intent);
        finish();
    }
    private ProgressDialog progressionDialogInitialize(String message) {
        ProgressDialog progressDialog = new ProgressDialog(this);
        progressDialog.setTitle(message);
        progressDialog.show();
        return progressDialog;
    }
}