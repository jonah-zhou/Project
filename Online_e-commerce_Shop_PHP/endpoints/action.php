<?php
declare(strict_types=1);

/*
 * Final_Project action.php
 * 
 * @author Nan Zhou (jonah)
 * @since 2023-03-20
 * (c) Copyright 2023 Nan Zhou 
 */

require_once "../includes/database.php";

/**
 * @throws Exception
 */

function action_query() : void
{
    $customer_id = query_customer($_REQUEST["username"],$_REQUEST["password"]);
    
    session_start();
    $_SESSION['customer_id'] = $customer_id;
    
    if($customer_id > 0){
        $url = "../public/pages/"."product.php?";
        header("Location: ".$url, true, 303);
        exit(0);
    }
    else{
        echo "The user [".$_REQUEST["username"]."]'s password is wrong! Login Denied!";
    }
}


function action_create() : void
{
    $customer_id = create_customer($_REQUEST["username"],$_REQUEST["password"]);
    
    session_start();
    $_SESSION['customer_id'] = $customer_id;
    
    if(is_int($customer_id)){
        $url = "../public/pages/"."customer.php";
        header("Location: ".$url,true,303);
        exit(0);
    }
    else{
        echo "The user [".$_REQUEST["username"]."] already exsit! Please Login.";
    }
}

function cartAction_create() : void
{
    $new_id = create_shoppingCart();
    $quantity = (int)$_POST["seleteQuantity"];
    $product_id = (int)$_POST["id"];
    if(is_int($new_id)){
        create_shoppingCartProduct($product_id,$new_id,$quantity);
        update_productAvailableQuantity($product_id, $quantity);
        $url = "../public/pages/"."cart.php";
        header("Location: ".$url,true,303);
        exit(0);
    }
}

function cartAction_update() : void
{
    $cartId = (int)htmlspecialchars($_POST['cartid']);
    $quantity = (int)htmlspecialchars($_POST['quantity']);
    $qty = (int)$_POST["qty"];
    $new_quantity = $quantity - $qty;
    $productId = (int)htmlspecialchars($_POST['productid']);
    update_shoppingCartProducts($cartId, $quantity, $new_quantity, $productId);
        $url = "../public/pages/"."cart.php";
        header("Location: ".$url,true,303);
        exit(0);
}

function cartAction_delete() : void
{
    $cartId = (int)htmlspecialchars($_POST['cartid']);
    $quantity = (int)htmlspecialchars($_POST['quantity']);
    $productId = (int)htmlspecialchars($_POST['productid']);
    $new_quantity = 0-$quantity;
    delete_shoppingCarts($cartId);
    update_productAvailableQuantity($productId,$new_quantity);
    $url = "../public/pages/"."cart.php";
    header("Location: ".$url,true,303);
    exit(0);
}

function order_create() : void
{
    $cartId = (int)htmlspecialchars($_POST['cartid']);
    $status = "Added";
    session_start();
    $customerid = $_SESSION['customer_id'];
    $new_id = create_order($status, $customerid, $cartId);
    update_cartStatus($cartId, $status);
    if(is_int($new_id)){
        $url = "../public/pages/"."order.php?id=$new_id";
        header("Location: ".$url,true,303);
        exit(0);
    }
}

function customer_update() : void
{
    update_customer((int) $_REQUEST["id"],$_REQUEST["username"], $_REQUEST["password"]);
    $url = "../public/pages/"."customer.php";
    header("Location: ".$url,true,303);
    exit(0);
}

function order_place() : void
{
    $order_id = intval($_POST['id']);
    $cartId = intval($_POST['cartid']);
    $status = "Placed";
    $placeDate = new DateTime();
    $shipDate = new DateTime();
    place_order($order_id, $cartId, $status, $placeDate, $shipDate);
    $url = "../public/pages/"."orderlist.php";
    header("Location: ".$url,true,303);
    exit(0);
}

//Use AJAX asynchronous requests to modify the content of pages
//Use jQuery to implement AJAX requests
function order_update() : void
{
    $order_id = (int)htmlspecialchars($_POST['id']);
    update_order((int) $_REQUEST["id"],$_REQUEST["billingaddress"], $_REQUEST["shippingaddress"]);
    $data = get_order_data($order_id);
    
    if (isset($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) === 'xmlhttprequest') {
        header('Content-Type: application/json');
        echo json_encode($data);
        exit();
    } else {
        $url = "../public/pages/"."order.php?id=$order_id";
        header("Location: ".$url,true,303);
        exit(0);
    }
}

if (!empty($_REQUEST["action"])) {
    switch ($_REQUEST["action"]) {
        case "query":
            try {
                action_query();
            } catch (Exception $e) {
            }
            break;
        case "create":
            action_create();
            break;
        default:
            echo "Invalid specified action: [".$_REQUEST["action"]."].";
            http_response_code(404);
    }
}

if (!empty($_REQUEST["productAction"])) {
    switch ($_REQUEST["productAction"]) {
        case "addToCart":
            cartAction_create();
            break;
        default:
            echo "Invalid specified action: [".$_REQUEST["productAction"]."].";
            http_response_code(404);
    }
}


if (!empty($_REQUEST["actionCustomer"])) {
    switch ($_REQUEST["actionCustomer"]) {
        case "update":
            customer_update();
            break;
        default:
            echo "Invalid specified action: [".$_REQUEST["customerUpdate"]."].";
            http_response_code(404);
    }
}


if (isset($_POST['updateCart'])) {
    cartAction_update();
} elseif (isset($_POST['deleleCart'])){
    cartAction_delete();
} elseif (isset($_POST['addOrder'])){
    order_create();
}

if (!empty($_REQUEST["actionOrder"])) {
    switch ($_REQUEST["actionOrder"]) {
        case "update":
            order_update();
            break;
        default:
            echo "Invalid specified action: [".$_REQUEST["actionOrder"]."].";
            http_response_code(404);
    }
}

if (!empty($_REQUEST["placeOrder"])) {
    switch ($_REQUEST["placeOrder"]) {
        case "update":
            order_place();
            break;
        default:
            echo "Invalid specified action: [".$_REQUEST["placeOrder"]."].";
            http_response_code(404);
    }
}

