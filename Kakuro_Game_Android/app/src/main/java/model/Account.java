package model;

import java.io.Serializable;

public class Account implements Serializable {
    private String accountId;
    private String email;
    private String password;
    public String getAccountId() {
        return accountId;
    }

    public void setAccountId(String accountId) {
        this.accountId = accountId;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Account() {
        this.accountId = null;
        this.email = null;
        this.password = null;
    }
    public Account(String accountId, String email, String password) {
        this.accountId = accountId;
        this.email = email;
        this.password = password;
    }
    @Override
    public String toString() {
        return "Account{" +
                "accountId='" + accountId + '\'' +
                ", email='" + email + '\'' +
                ", password='" + password + '\'' +
                '}';
    }

}
