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

$new_id = htmlspecialchars($_GET['id']);
$sql = 'SELECT * FROM orders WHERE ID = :id';
$stmt = $pdo->prepare($sql);
$stmt->execute(['id' => $new_id]);
$order = $stmt->fetch(PDO::FETCH_ASSOC);

?>

<?php
$sql = "SELECT * FROM orders JOIN shoppingcartproducts
    JOIN products ON orders.shoppingCartId = shoppingcartproducts.shoppingCartId
    AND shoppingcartproducts.productId = products.id
    WHERE orders.id = '{$order["id"]}' AND orders.shoppingCartId = '{$order["shoppingCartId"]}'";
$stmt = $pdo->prepare($sql);
$stmt->execute();
$orderProduct = $stmt->fetch(PDO::FETCH_ASSOC);
$totalPrice = $orderProduct["quantity"] * $orderProduct["unitPrice"] * 1.15;

?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <title>Order Page</title>
        <link rel="stylesheet" href="../css/productcss.css">
    </head>
    <body>
        <header class="container">
            <h1 class="logo">Order Details</h1>
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
<!--Use jQuery to implement AJAX requests-->
    <script>
        $(document).ready(function () {
            $('form[name="orderForm"]').submit(function (event) {
                event.preventDefault();
                var formData = $(this).serialize() + "&actionOrder=update";
    
                $.ajax({
                           url: "../../endpoints/action.php",
                           type: "POST",
                           data: formData,
                           success: function (response) {
                               $('#billingaddress').val(response.billingAddress);
                               $('#shippingaddress').val(response.shippingAddress);
                           },
                           error: function () {
                               alert("Error updating order.");
                           }
                       });
            });
        });
    </script>
        <ul class="customer-list">
            <form name="orderForm" method="POST" action="../../endpoints/action.php">
                <li>
                    <input type="hidden" id="actionOrder" name="actionOrder" value="update">
                    <div class="input-row">
                        <label for="id">ID: </label>
                        <input class="form-input" type="number" id="id" name="id" value="<?=$order["id"]?>" readonly>
                    </div>
                    <div class="input-row">
                        <label for="status">Status: </label>
                        <input class="form-input editable-form-input" type="text" id="status" name="status" maxlength="256"
                               value="<?=$order["status"]?>" readonly>
                    </div>
                    <div class="input-row">
                        <label for="customerid">CustomerId: </label>
                        <input class="form-input editable-form-input" type="number" id="customerid" name="customerid" maxlength="256"
                               value="<?=$order["customerId"]?>" readonly>
                    </div>
                    <div class="input-row">
                        <label for="shoppingCartId">CartId: </label>
                        <input class="form-input editable-form-input" type="number" id="cartid" name="cartid" maxlength="256"
                               value="<?=$order["shoppingCartId"]?>" readonly>
                    </div>
                    <div class="input-row">
                        <label for="totalprice">Total Price(Tax included): </label>
                        <input class="form-input editable-form-input" type="number" id="totalprice" name="totalprice" maxlength="256"
                               value="<?=$totalPrice?>" readonly>
                    </div>
                    <div class="input-row">
                        <label for="billingAddress">Billing Address: </label>
                        <input class="form-input editable-form-input" type="text" id="billingaddress" name="billingaddress" maxlength="256"
                               value="<?=$order["billingAddress"]?>">
                    </div>
                    <div class="input-row">
                        <label for="shippingAddress">Shipping Address: </label>
                        <input class="form-input editable-form-input" type="text" id="shippingaddress" name="shippingaddress" maxlength="256"
                               value="<?=$order["shippingAddress"]?>">
                    </div>
                    <div class="input-row">
                        <label for="dateCreated">Date Created: </label>
                        <div class="input-container">
                            <input class="form-input" type="datetime-local" id="dateCreated" name="dateCreated" value="<?=$order["dateCreated"]?>" readonly>
                        </div>
                    </div>
                    <div class="input-row">
                        <label for="datePlaced">Date Placed: </label>
                        <div class="input-container">
                            <input class="form-input" type="datetime-local" id="dateplaced" name="dateplaced" value="<?=$order["datePlaced"]?>" readonly>
                        </div>
                    </div>
                    <div class="input-row">
                        <label for="dateShipped">Date Shipped: </label>
                        <div class="input-container">
                            <input class="form-input" type="datetime-local" id="dateshipped" name="dateshipped" value="<?=$order["dateShipped"]?>" readonly>
                        </div>
                    </div>
                    <div class="input-row-buttons">
                        <input type="submit" id="submit" value="Update">
                    </div>
                </li>
            </form>
            <form name="orderPlaceForm" method="POST" action="../../endpoints/action.php">
                <input type="hidden" id="placeOrder" name="placeOrder" value="update">
                <div class="input-row-buttons">
                    <input type="hidden" name="id" value="<?php echo htmlspecialchars($new_id); ?>">
                    <input type="hidden" name="cartid" value="<?php echo $order["shoppingCartId"] ?>">
                    <input type="submit" id="placeOrderButton" name="placeOrderButton" value="PLACE ORDER">
                </div>
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
