package com.example.kakuro_game_android;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.firestore.FirebaseFirestore;

import model.Account;
import model.Player;
import data.PlayerAccountDB;

public class LoginActivity extends AppCompatActivity implements View.OnClickListener {
    TextView textViewRegister;
    EditText edTextEmail, edTextPassword;
    Button btnLogin, btnGuest;
    FirebaseAuth mAuth;

    FirebaseFirestore database;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        initialize();
    }
    @Override
    public void onStart() {
        super.onStart();
        FirebaseAuth mAuth = FirebaseAuth.getInstance();
        FirebaseUser currentUser = mAuth.getCurrentUser();
        if (currentUser != null) {
            Player.getSessionAccount(currentUser.getEmail(), new Player.GetSessionAccountListener() {
                @Override
                public void onGetSessionAccountSuccess(Player existingPlayer) {
                    redirectMenuPage(existingPlayer);
                }

                @Override
                public void onGetSessionAccountFailed(String message) {
                    displayMessage(message);
                }
            });
        }

    }
    private void initialize() {
        edTextEmail = findViewById(R.id.edEmail);
        edTextPassword = findViewById(R.id.edPassword);
        textViewRegister = findViewById(R.id.textViewRegister);

        btnLogin = findViewById(R.id.btnLogin);
        btnGuest = findViewById(R.id.btnGuest);

        mAuth = FirebaseAuth.getInstance();
        database = FirebaseFirestore.getInstance();

        textViewRegister.setOnClickListener(this);
        btnLogin.setOnClickListener(this);
        btnGuest.setOnClickListener(this);
    }

    @Override
    public void onClick(View v) {
        if (v.getId() == R.id.btnLogin) {

            String email = String.valueOf(edTextEmail.getText());
            String password = String.valueOf(edTextPassword.getText());

            boolean isValid = verifyInput(email, password);
            if (isValid) {
                ProgressDialog progressDialog = progressionDialogInitialize("Logging in ...");
                Player.login(email, password, new Player.ProcessListener() {
                    @Override
                    public void onProcessSuccess(Player playerLogin) {
                        displayMessage("Login Successfully");
                        progressDialog.dismiss();
                        redirectMenuPage(playerLogin);
                    }
                    @Override
                    public void onProcessFailed(String message) {
                        displayMessage(message);
                        progressDialog.dismiss();
                    }
                });
            }
            else {
                displayMessage("Incorrect Email or Password Format");
            }
        }
        else if (v.getId() == R.id.textViewRegister) {
            redirectRegistration();
        }
        else if (v.getId() == R.id.btnGuest) {
            Player guest = Player.loginAsGuest();
            redirectMenuPage(guest);
        }
    }

    private boolean verifyInput(String email, String password) {

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
        if (!password.matches("^\\w{8,16}$")) {
            displayMessage("Password must between 8 to 16 characters");
            return false;
        }
        return true;
    }
    private void displayMessage(String message) {
        Toast.makeText(LoginActivity.this, message, Toast.LENGTH_SHORT).show();
    }
    private void redirectMenuPage(Player player) {
        Intent intent = new Intent(getApplicationContext(), GameMenuActivity.class);
        intent.putExtra("playerLogin", player);
        startActivity(intent);
        finish();
    }
    private void redirectRegistration(){
        Intent intent = new Intent(getApplicationContext(), RegistrationActivity.class);
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