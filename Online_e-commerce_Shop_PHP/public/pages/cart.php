<?php
declare(strict_types=1);

/*
 * Final_Project cart.php
 * 
 * @author Nan Zhou (jonah)
 * @since 2023-03-25
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
        <title>Cart Details Page</title>
        <link rel="stylesheet" href="../css/productcss.css">
    </head>
    <body>
        <header class="container">
            <h1 class="logo">Cart Details</h1>
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
    $sql = 'SELECT * FROM shoppingcarts JOIN shoppingcartproducts
    JOIN products ON shoppingcarts.id = shoppingcartproducts.shoppingCartId AND shoppingcartproducts.productId = products.id
    ORDER BY shoppingcarts.id';
    $stmt = $pdo->prepare($sql);
    $stmt->execute();
    $cartProducts = $stmt->fetchAll(PDO::FETCH_ASSOC);
    
    echo '<ul class="products-list">';
    foreach ($cartProducts as $cartProduct) {
        echo '<form name="cartForm" method="POST" action="../../endpoints/action.php">';
        echo '<li>';
        echo '<div class="product-output-row" >';
        echo '<label for="cartid">Cart ID: </label>';
        echo '<input class="form-output" type="number" id="cartid" name="cartid" value="'.$cartProduct["shoppingCartId"].'" readonly>';
        echo '</div>';
        echo '<div class="product-output-row">';
        echo '<label for="cartstatus">Cart Status: </label>';
        echo '<input class="form-output" type="text" id="cartstatus" name="cartstatus" value="'.$cartProduct["status"].'" readonly>';
        echo '</div>';
        echo '<div class="product-output-row" >';
        echo '<label for="productname">Product Name: </label>';
        echo '<input class="form-output" type="text" id="productname" name="productname" value="'.$cartProduct["displayName"].'" readonly>';
        echo '</div>';
        echo '<div class="product-output-row" >';
        echo '<label for="quantity">Order Quantity: </label>';
        echo '<input class="form-output" type="number" id="quantity" name="quantity" value="'.$cartProduct["quantity"].'" min="1" max="'.$cartProduct["availableQuantity"].'">';
        echo '</div>';
        echo '<div class="product-output-row">';
        echo '<div class="product-buttons">';
        echo '<input type="hidden" name="cartUpdate" value="update">';
        echo '<input type="hidden" name="cartid" value="'.$cartProduct["shoppingCartId"].'">';
        echo '<input type="hidden" name="qty" value="'.$cartProduct["quantity"].'">';
        echo '<input type="hidden" name="productid" value="'.$cartProduct["productId"].'">';
        if ($cartProduct["status"] == "NotOrdered") {
            echo '<input type="submit" id="submitupdate" name="updateCart" value="Update" onclick="document.cartForm.submit();">';
        }
        if ($cartProduct["status"] == "NotOrdered") {
            echo '</div>';
        }
        echo '<div class="product-buttons">';
        echo '<input type="hidden" name="cartDelete" value="delete">';
        echo '<input type="hidden" name="cartid" value="'.$cartProduct["shoppingCartId"].'">';
        echo '<input type="hidden" name="productid" value="'.$cartProduct["productId"].'">';
        if ($cartProduct["status"] == "NotOrdered") {
            echo '<input type="submit" id="submitdelete" name="deleleCart" value="Delete" onclick="document.cartForm.submit();">';
        }
        if ($cartProduct["status"] == "NotOrdered") {
            echo '</div>';
        }
        echo '<div class="product-buttons">';
        echo '<input type="hidden" name="addOrder" value="create">';
        echo '<input type="hidden" name="cartid" value="'.$cartProduct["shoppingCartId"].'">';
        if ($cartProduct["status"] == "NotOrdered") {
            echo '<input type="submit" id="submitcreate" name="addOrder" value="Add To Order" onclick="document.cartForm.submit();">';
        }
        if ($cartProduct["status"] == "NotOrdered") {
            echo '</div>';
        }
        echo '</div>';
        echo '</li>';
        echo '</form>';
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

