<?php
declare(strict_types=1);

/*
 * Final_Project product.php
 * 
 * @author Nan Zhou (jonah)
 * @since 2023-03-21
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
        <title>Product List Page</title>
        <link rel="stylesheet" href="../css/productcss.css">
    </head>
    <body>
        <header class="container">
            <h1 class="logo">Product List</h1>
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
    $sql = 'SELECT * FROM products ORDER BY products.id';
    $stmt = $pdo->prepare($sql);
    $stmt->execute();
    $products = $stmt->fetchAll(PDO::FETCH_ASSOC);
    echo '<ul class="products-list">';
    foreach ($products as $product) {
        echo '<form method="POST" action="../../endpoints/action.php">';
        echo '<li>';
        echo '<input type="hidden" name="productAction" value="addToCart">';
        echo '<div class="product-output-row" >';
        echo '<label for="id">ID: </label>';
        echo '<input class="form-output" type="number" id="id" name="id" value="'.$product["id"].'" readonly>';
        echo '</div>';
        echo '<div class="product-output-row">';
        echo '<label for="displayName">Product Name: </label>';
        echo '<input class="form-output" type="text" id="displayName" name="displayName" value="'.$product["displayName"].'" readonly>';
        echo '</div>';
        echo '<div class="product-output-row">';
        echo '<label for="availableQuantity">Available Quantity: </label>';
        echo '<input class="form-output" type="number" id="seleteQuantity" name="seleteQuantity" value="'.$product["availableQuantity"].'" min="1" max="'.$product["availableQuantity"].'">';
        echo '</div>';
        echo '<div class="product-output-row">';
        echo '<div class="product-buttons">';
        echo '<button type="button" onclick="location.href=\'productdetail.php?id='.$product["id"].'\'" class="green-button">Product Details</button>';
        echo '</div>';
        echo '<div class="product-buttons">';
        echo '<button type="submit" name="id" value="'.$product["id"].'" class="green-button">Add to Cart</button>';
        echo '</div>';
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



