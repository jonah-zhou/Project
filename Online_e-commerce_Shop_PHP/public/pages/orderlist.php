<?php
declare(strict_types=1);

/*
 * Final_Project order.php
 * 
 * @author Nan Zhou (jonah)
 * @since 2023-04-08
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

?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <title>Order List Page</title>
        <link rel="stylesheet" href="../css/productcss.css">
    </head>
    <body>
        <header class="container">
            <h1 class="logo">Order List</h1>
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

    <?php
    session_start();
    $customer_id = $_SESSION['customer_id'];
    
    $sql = 'SELECT * FROM orders WHERE status = "Placed" AND `customerId` = :id ';
    $stmt = $pdo->prepare($sql);
    $stmt->execute(['id' => $customer_id]);
    $orders = $stmt->fetchAll(PDO::FETCH_ASSOC);
    
    echo '<ul class="customer-list">';
    foreach ($orders as $order) {
    
        $sql = "SELECT * FROM orders
            JOIN shoppingcartproducts ON orders.shoppingCartId = shoppingcartproducts.shoppingCartId
            JOIN products ON shoppingcartproducts.productId = products.id
            WHERE orders.id = '{$order["id"]}' ORDER BY orders.id";
        $stmt = $pdo->prepare($sql);
        $stmt->execute();
        $orderProduct = $stmt->fetch(PDO::FETCH_ASSOC);
        $totalPrice = $orderProduct["quantity"] * $orderProduct["unitPrice"] * 1.15;
    echo '<li>';
    echo '<div class="input-row">';
    echo '<label for="id">ID: </label>';
    echo '<input class="form-input" type="number" id="id" name="id" value="'.$order["id"].'" readonly>';
    echo '</div>';
    echo '<div class="input-row">';
    echo '<label for="status">Status: </label>';
    echo '<input class="form-input editable-form-input" type="text" id="status" name="status" maxlength="256" value="'.$order["status"].'" readonly>';
    echo '</div>';
    echo '<div class="input-row">';
    echo '<label for="customerid">CustomerId: </label>';
    echo '<input class="form-input editable-form-input" type="number" id="customerid" name="customerid" maxlength="256" value="'.$order["customerId"].'" readonly>';
    echo '</div>';
    echo '<div class="input-row">';
    echo '<label for="shoppingCartId">CartId: </label>';
    echo '<input class="form-input editable-form-input" type="number" id="cartid" name="cartid" maxlength="256" value="'.$order["shoppingCartId"].'" readonly>';
    echo '</div>';
    echo '<div class="input-row">';
    echo '<label for="totalprice">Total Price(Tax included): </label>';
    echo '<input class="form-input editable-form-input" type="number" id="totalprice" name="totalprice" maxlength="256" value="'.$totalPrice.'" readonly>';
    echo '</div>';
    echo '<div class="input-row">';
    echo '<label for="billingAddress">Billing Address: </label>';
    echo '<input class="form-input editable-form-input" type="text" id="billingaddress" name="billingaddress" maxlength="256" value="'.$order["billingAddress"].'" readonly>';
    echo '</div>';
    echo '<div class="input-row">';
    echo '<label for="shippingAddress">Shipping Address: </label>';
    echo '<input class="form-input editable-form-input" type="text" id="shippingaddress" name="shippingaddress" maxlength="256" value="'.$order["shippingAddress"].'" readonly>';
    echo '</div>';
    echo '<div class="input-row">';
    echo '<label for="dateCreated">Date Created: </label>';
    echo '<div class="input-container">';
    echo '<input class="form-input" type="datetime-local" id="dateCreated" name="dateCreated" value="'.$order["dateCreated"].'" readonly>';
    echo '</div>';
    echo '</div>';
    echo '<div class="input-row">';
    echo '<label for="datePlaced">Date Placed: </label>';
    echo '<div class="input-container">';
    echo '<input class="form-input" type="datetime-local" id="dateplaced" name="dateplaced" value="'.$order["datePlaced"].'" readonly>';
    echo '</div>';
    echo '</div>';
    echo '<div class="input-row">';
    echo '<label for="dateShipped">Date Shipped: </label>';
    echo '<div class="input-container">';
    echo '<input class="form-input" type="datetime-local" id="dateshipped" name="dateshipped" value="'.$order["dateShipped"].'" readonly>';
    echo '</div>';
    echo '</div>';
    echo '</li>';
    }
    echo '</ul>';
    ?>
    
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
