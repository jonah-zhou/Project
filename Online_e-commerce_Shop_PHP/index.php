<?php
declare(strict_types=1);

/*
 * Final_Project index.php
 * 
 * @author Nan Zhou (jonah)
 * @since 2023-02-13
 * (c) Copyright 2023 Nan Zhou 
 */
?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <title>Register/Login Page</title>
        <link rel="stylesheet" href="public/css/indexcss.css">
    </head>
    <body id="login-page">
        <div class="register-box">
            <h2>Register Here</h2>
            <form method="post" action="endpoints/action.php">
                <input type="hidden" id="actionInput" name="action" value="create">
                <div class="index-input-row">
                    <label>Username</label>
                    <input type="text" id="username" name="username" required>
                </div>
                <div class="index-input-row">
                    <label>Password</label>
                    <input type="password" id="password" name="password" required>
                </div>
                <div class="index-input-row">
                    <input type="submit" id="submit" value="Submit">
                </div>
            </form>
        </div>
        <div class="login-box">
            <h2>Login Here</h2>
            <form method="post" action="endpoints/action.php">
                <input type="hidden" id="actionInput" name="action" value="query">
                <div class="index-input-row">
                    <label>Username</label>
                    <input type="text" id="username" name="username" required>
                </div>
                <div class="index-input-row">
                    <label>Password</label>
                    <input type="password" id="password" name="password" required>
                </div>
                <div class="index-input-row">
                    <input type="submit" id="submit" value="Submit">
                </div>
            </form>
        </div>
    </body>
</html>
