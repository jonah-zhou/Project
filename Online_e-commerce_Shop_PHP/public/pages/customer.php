<?php
declare(strict_types=1);

/*
 * Final_Project customer.php
 * 
 * @author Nan Zhou (jonah)
 * @since 2023-03-20
 * (c) Copyright 2023 Nan Zhou 
 */

$dsn = 'mysql:host=localhost;dbname=final_project';
$username = 'root';
$password = '';
$options = array(
        PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES utf8',
);

try {
    $pdo = new PDO($dsn, $username, $password, $options);
} catch (PDOException $e) {
    echo 'Connection failed: '.$e->getMessage();
}

session_start();
$customer_id = $_SESSION['customer_id'];

$sql = 'SELECT * FROM customers WHERE `id` = :id';
$stmt = $pdo->prepare($sql);
$stmt->execute(['id' => $customer_id]);
$customer = $stmt->fetch(PDO::FETCH_ASSOC);
?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <title>Customer Page</title>
        <link rel="stylesheet" href="../css/productcss.css">
    </head>
    <body>
        <header class="container">
            <h1 class="logo">Customer List</h1>
            <nav class="menu-options">
                <ul>
                    <li><a href="product.php">Product List</a></li>
                    <li><a href="cart.php">Cart</a></li>
                    <li><a href="orderlist.php">Order</a></li>
                    <li><a href="customer.php">Customer</a></li>
                    <li><a href="../../index.php">Exit</a></li>
                </ul>
            </nav>
        </header>
        <ul class="customer-list">
            <form name="customerForm" method="POST" action="../../endpoints/action.php">
                <li>
                    <input type="hidden" id="actionCustomer" name="actionCustomer" value="update">
                    <div class="input-row">
                        <label for="id">ID: </label>
                        <input class="form-input" type="number" id="id" name="id" value="<?=$customer["id"]?>" readonly>
                    </div>
                    <div class="input-row">
                        <label for="username">Username: </label>
                        <input class="form-input editable-form-input" type="text" id="username" name="username" maxlength="256"
                               value="<?=$customer["username"]?>">
                    </div>
                    <div class="input-row">
                        <label for="password">Password: </label>
                        <input class="form-input editable-form-input" type="text" id="password" name="password" maxlength="256"
                               value="<?=$customer["passwordHash"]?>">
                    </div>
                    <div class="input-row">
                        <label for="dateCreated">Date Created: </label>
                        <div class="input-container">
                            <input class="form-input" type="datetime-local" id="dateCreated" name="dateCreated" value="<?=$customer["dateCreated"]?>" readonly>
                        </div>
                    </div>
                    <div class="input-row-buttons">
                            <input type="submit" id="submit" value="Update">
                    </div>
                </li>
            </form>
        </ul>
        <footer>
            <div class="container">
                <ul class="social">
                    <li><a href="#"><img src="../media/images/facebook.png" alt="Facebook"></a></li>
                    <li><a href="#"><img src="../media/images/twitter.png" alt="Twitter"></a></li>
                    <li><a href="#"><img src="../media/images/googleplus.png" alt="Google"></a></li>
                </ul>
            </div>
        </footer>
    </body>
</html>
