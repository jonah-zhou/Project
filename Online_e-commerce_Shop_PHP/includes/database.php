<?php
declare(strict_types=1);

/*
 * Final_Project database.php
 * 
 * @author Nan Zhou (jonah)
 * @since 2023-03-20
 * (c) Copyright 2023 Nan Zhou 
 */


const DB_USER = "root";
const DB_PASSWD = "";
const DB_NAME = "final_project";
const DB_TABLE = "customers";

function get_connection() : mysqli
{
    return new mysqli("localhost",DB_USER,DB_PASSWD,DB_NAME,3306);
}


/**
 * @throws Exception
 */
function get_customer(int $id) : array
{
    $connection = get_connection();
    $statement = $connection->prepare("SELECT * FROM `".DB_TABLE."` WHERE `id` = ? ;");
    $statement->bind_param("i",$id);
    $statement->execute();
    $result_set = $statement->get_result();
    if($result_set->num_rows == 0)
    {
        return [];
    }
    elseif ($result_set->num_rows > 1)
    {
        throw new Exception("Error! Should not have more than one record!");
    }
    return $result_set->fetch_assoc();
}

/**
 * @throws Exception
 */
function query_customer(string $username, string $password) : int
{
    $connection = get_connection();
    $statement = $connection->prepare("SELECT * FROM `".DB_TABLE."` WHERE `username` = ? AND `passwordHash` = ? ;");
    $statement->bind_param("ss",$username,$password);
    $statement->execute();
    $result_set = $statement->get_result();
    $new_id = -1;
    if($result_set->num_rows == 1)
    {
        $new_id = $result_set->fetch_column();
    }
    elseif ($result_set->num_rows == 0) {
        $statement = $connection->prepare("SELECT * FROM `".DB_TABLE."` WHERE `username` = ? ;");
        $statement->bind_param("s", $username);
        $statement->execute();
        $result_set = $statement->get_result();
        if ($result_set->num_rows == 0) {
            $new_id = create_customer($username, $password);
        }
    }
    return $new_id;
}

function create_customer(string $username, string $password) : int|array
{
    $connection = get_connection();
    $connection->begin_transaction();
    try {
        $statement = $connection->prepare("INSERT INTO `".DB_TABLE."` (`username`, `passwordHash`) VALUES (?, ?);");
        $statement->bind_param("ss",$username,$password);
        $statement->execute();
        $new_id = $connection->insert_id;
        $connection->commit();
        return $new_id;
    }
    catch (mysqli_sql_exception $mysql_exception){
        $connection->rollback();
        return [
            "errno" => $connection->errno,
            "error" => $connection->error,
            "exception" => $mysql_exception
        ];
    }
}

function create_shoppingCart() : int | array
{
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
    $sql = 'INSERT INTO `shoppingcarts` (`id`) VALUES (NULL);';
    $stmt = $pdo->prepare($sql);
    $stmt->execute();
    $new_Id = (int)$pdo->lastInsertId();
    return $new_Id;
}

function create_shoppingCartProduct(int $productId, int $cartId, int $quantity) : int|array
{
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
    $sql = 'INSERT INTO `shoppingcartproducts` (`productId`, `shoppingCartId`, `quantity`) VALUES (:productId, :cartId, :quantity)';
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':productId', $productId);
    $stmt->bindParam(':cartId', $cartId);
    $stmt->bindParam(':quantity', $quantity);
    $stmt->execute();
    $shoppingCartProducts = $stmt->fetchAll(PDO::FETCH_ASSOC);
    return $shoppingCartProducts;
}

function update_shoppingCartProducts(int $cartId, int $quantity, int $new_quantity, int $productId) : void
{
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
    $sql = 'UPDATE `shoppingcartproducts` SET `quantity` = :quantity WHERE `shoppingCartId` = :cartId';
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':quantity', $quantity);
    $stmt->bindParam(':cartId', $cartId);
    $stmt->execute();
    $quantity = (int) $quantity;
    update_productAvailableQuantity($productId, $new_quantity);
}

function delete_shoppingCartProducts(int $cartId) : void
{
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
    $sql = 'DELETE FROM `shoppingcartproducts` WHERE `shoppingCartId` = :cartId';
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':cartId', $cartId);
    $stmt->execute();
}

function delete_shoppingCarts(int $cartId) : void
{
    delete_shoppingCartProducts($cartId);
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
    $sql = 'DELETE FROM `shoppingcarts` WHERE `id` = :cartId';
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':cartId', $cartId);
    $stmt->execute();
}


function update_productAvailableQuantity(int $productId,int $quantity) : void
{
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
    $sql = 'SELECT `availableQuantity` FROM `products` WHERE `id` = :productId';
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':productId', $productId);
    $stmt->execute();
    $result = $stmt->fetch(PDO::FETCH_ASSOC);
    if ($result['availableQuantity'] >= $quantity) {
        $qty = $result['availableQuantity'] - $quantity;
        $sql = 'UPDATE `products` SET `availableQuantity` = :qty WHERE `id` = :productId';
        $stmt = $pdo->prepare($sql);
        $stmt->bindParam(':qty', $qty);
        $stmt->bindParam(':productId', $productId);
        $stmt->execute();
    }
    else{
        echo "error";
    }
}

function create_order(string $status, int $customerId, int $shoppingCartId) : int | array
{
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
    $sql = 'INSERT INTO `orders` (`status`, `customerId`, `shoppingCartId`) VALUES (:status, :customerId, :shoppingCartId)';
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':status', $status);
    $stmt->bindParam(':customerId', $customerId);
    $stmt->bindParam(':shoppingCartId', $shoppingCartId);
    $stmt->execute();
    $new_Id = (int)$pdo->lastInsertId();
    return $new_Id;
}

function update_customer(int $customerId, string $userName, string $passwordHash) : void
{
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
    $sql = 'UPDATE `customers` SET `username` = :username, `passwordHash` = :password WHERE `id` = :customerid';
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':username', $userName);
    $stmt->bindParam(':password', $passwordHash);
    $stmt->bindParam(':customerid', $customerId);
    $stmt->execute();
}

function update_cartStatus(int $cartId, string $status) : void
{
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
    $sql = 'UPDATE `shoppingcarts` SET `status` = :status WHERE `id` = :id';
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':status', $status);
    $stmt->bindParam(':id', $cartId);
    $stmt->execute();
}


function update_order(int $orderId, string $billingAddress, string $shippingAddress) : void
{
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
    $sql = 'UPDATE `orders` SET `billingAddress` = :billingaddress, `shippingAddress` = :shippingaddress WHERE `id` = :orderid';
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':billingaddress', $billingAddress);
    $stmt->bindParam(':shippingaddress', $shippingAddress);
    $stmt->bindParam(':orderid', $orderId);
    $stmt->execute();
}

function get_order_data(int $orderId) : array
{
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
    $sql = 'SELECT * FROM `orders` WHERE `id` = :orderid';
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':orderid', $orderId);
    $stmt->execute();
    return $stmt->fetch(PDO::FETCH_ASSOC);
}

function place_order(int $orderId, int $cartId, string $status, datetime $placeDate, datetime $shipDate) : void
{
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
    $placeDate = new DateTime();
    $placeDateStr = $placeDate->format('Y-m-d H:i:s');
    $shipDate = new DateTime();
    $shipDateStr = $shipDate->format('Y-m-d H:i:s');
    
    
    $sql = 'UPDATE `orders` SET `status` =:status, `datePlaced` = :placedate, `dateShipped` = :shipdate WHERE `id` = :orderid';
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':orderid', $orderId);
    $stmt->bindParam(':status', $status);
    $stmt->bindParam(':placedate', $placeDateStr);
    $stmt->bindParam(':shipdate', $shipDateStr);
    $stmt->execute();
    
    $sql = 'UPDATE `shoppingcarts` SET `status` =:status WHERE `id` = :cartid';
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':cartid', $cartId);
    $stmt->bindParam(':status', $status);
    $stmt->execute();
}






