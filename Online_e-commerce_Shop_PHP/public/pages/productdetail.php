<?php
declare(strict_types=1);

/*
 * Final_Project productdetail.php
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

$id = htmlspecialchars($_GET['id']);
$sql = 'SELECT * FROM products WHERE ID = :id';
$stmt = $pdo->prepare($sql);
$stmt->execute(['id' => $id]);
$product = $stmt->fetch(PDO::FETCH_ASSOC);
?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <title>Product Details Page</title>
        <link rel="stylesheet" href="../css/productcss.css">
    </head>
    <body>
        <header class="container">
            <h1 class="logo">Product Details</h1>
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
        <form name="productForm" method="POST" action="../../endpoints/action.php">
            <input type="hidden" name="productAction" value="addToCart">
            <input type="hidden" name="id" value="<?=$product["id"]?>">
            <ul class="product-form-details">
                <li>
                    <div class="product-output-row">
                        <label for="id">ID: </label>
                        <input class="form-output" type="number" id="id" name="id" value="<?=$product["id"]?>" readonly>
                    </div>
                    <div class="product-output-row">
                        <label for="displayName">Product Name: </label>
                        <input class="form-output" type="text" id="displayName" name="displayName" value="<?=$product["displayName"]?>" readonly>
                    </div>
                    <div class="product-output-row">
                        <label for="description">Description: </label>
                        <input class="form-output" type="text" id="description" name="description" value="<?=$product["description"]?>" readonly>
                    </div>
                    <div class="product-output-row">
                        <label for="imageUrl">Product Image: </label>
                        <img class="product-image" src="<?=$product["imageUrl"]?>" alt="Product Image">
                    </div>
                    <div class="product-output-row">
                        <label for="unitPrice">Unit Price: </label>
                        <input class="form-output" type="number" id="unitPrice" name="unitPrice" value="<?=$product["unitPrice"]?>" readonly>
                    </div>
                    <div class="product-output-row">
                        <label for="availableQuantity">Available Quantity: </label>
                        <input class="form-output" type="number" id="availableQuantity" name="availableQuantity" value="<?=$product["availableQuantity"]?>" readonly>
                    </div>
                    <div class="product-output-row">
                        <label for="seleteQuantity">Selete Quantity: </label>
                        <input class="form-output" type="number" id="seleteQuantity" name="seleteQuantity" value="1" min="0" max="<?=$product["availableQuantity"]?>">
                    </div>
                    <div class="product-output-row">
                        <label for="dateCreated">Date Created: </label>
                        <input class="form-output" type="datetime-local" id="dateCreated" name="dateCreated" value="<?=$product["dateCreated"]?>" readonly>
                    </div>
                    <div class="product-output-row">
                        <input type="submit" id="submit" value="Add To Cart" onclick="document.productForm.submit();">
                    </div>
                </li>
            </ul>
        </form>
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


