-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 20, 2023 at 09:11 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET FOREIGN_KEY_CHECKS=0;
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `final_project`
--
CREATE DATABASE IF NOT EXISTS `final_project` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `final_project`;

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
CREATE TABLE IF NOT EXISTS `customers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(25) NOT NULL,
  `passwordHash` varchar(25) NOT NULL,
  `dateCreated` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`id`, `username`, `passwordHash`, `dateCreated`) VALUES
(1, 'user1', '111', '2023-03-20 17:24:17'),
(2, 'user2', '222', '2023-03-21 15:50:02'),
(4, 'user3', '333', '2023-04-20 13:42:08'),
(5, 'user4', '444', '2023-04-20 13:49:01');

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `status` varchar(10) NOT NULL,
  `customerId` int(11) NOT NULL,
  `shoppingCartId` int(11) NOT NULL,
  `billingAddress` varchar(50) NOT NULL,
  `shippingAddress` varchar(50) NOT NULL,
  `dateCreated` datetime NOT NULL DEFAULT current_timestamp(),
  `datePlaced` datetime NOT NULL,
  `dateShipped` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `orders_customers_Id` (`customerId`),
  KEY `orders_shoppingcarts_Id` (`shoppingCartId`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`id`, `status`, `customerId`, `shoppingCartId`, `billingAddress`, `shippingAddress`, `dateCreated`, `datePlaced`, `dateShipped`) VALUES
(31, 'Placed', 2, 76, '1234 Rue Sunbay', '4567 Rue Congress ', '2023-04-20 14:48:07', '2023-04-20 14:48:41', '2023-04-20 14:48:41'),
(32, 'Placed', 1, 77, '1190 Rue Montcalm', '1190 Rue Montcalm', '2023-04-20 14:49:09', '2023-04-20 14:49:37', '2023-04-20 14:49:37'),
(33, 'Added', 1, 79, '111 stone street', '111 stone street', '2023-04-20 14:50:13', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(34, 'Placed', 1, 80, '1190 Rue Montcalm', '1190 Rue Montcalm', '2023-04-20 14:52:33', '2023-04-20 14:52:44', '2023-04-20 14:52:44');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
CREATE TABLE IF NOT EXISTS `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `displayName` varchar(25) NOT NULL,
  `description` varchar(50) NOT NULL,
  `imageUrl` varchar(256) NOT NULL,
  `unitPrice` float NOT NULL,
  `availableQuantity` int(11) NOT NULL,
  `dateCreated` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `displayName`, `description`, `imageUrl`, `unitPrice`, `availableQuantity`, `dateCreated`) VALUES
(1, 'Car', 'Car Model', '../media/images/car.jpg', 500, 18, '2023-03-21 15:47:35'),
(2, 'Motorcycle ', 'Motor Model', '../media/images/motor.jpg', 200, 28, '2023-03-21 15:48:05'),
(3, 'Bicycle ', 'Bike Model', '../media/images/bike.jpg', 100, 49, '2023-03-22 13:47:40'),
(4, 'BMW', 'BMW Model', '../media/images/bmw.jpg', 1000, 9, '2023-03-22 13:52:10');

-- --------------------------------------------------------

--
-- Table structure for table `shoppingcartproducts`
--

DROP TABLE IF EXISTS `shoppingcartproducts`;
CREATE TABLE IF NOT EXISTS `shoppingcartproducts` (
  `productId` int(11) NOT NULL,
  `shoppingCartId` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  PRIMARY KEY (`productId`,`shoppingCartId`),
  UNIQUE KEY `shoppingCartId` (`shoppingCartId`),
  KEY `ShoppingCartProducts_Products_Id` (`productId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `shoppingcartproducts`
--

INSERT INTO `shoppingcartproducts` (`productId`, `shoppingCartId`, `quantity`) VALUES
(1, 77, 2),
(2, 78, 1),
(2, 80, 1),
(3, 79, 1),
(4, 76, 1);

-- --------------------------------------------------------

--
-- Table structure for table `shoppingcarts`
--

DROP TABLE IF EXISTS `shoppingcarts`;
CREATE TABLE IF NOT EXISTS `shoppingcarts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `status` varchar(15) NOT NULL DEFAULT 'NotOrdered',
  `dateCreated` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `shoppingcarts`
--

INSERT INTO `shoppingcarts` (`id`, `status`, `dateCreated`) VALUES
(76, 'Placed', '2023-04-20 14:48:01'),
(77, 'Placed', '2023-04-20 14:49:05'),
(78, 'NotOrdered', '2023-04-20 14:49:47'),
(79, 'Added', '2023-04-20 14:50:05'),
(80, 'Placed', '2023-04-20 14:52:16');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_customers_Id` FOREIGN KEY (`customerId`) REFERENCES `customers` (`id`),
  ADD CONSTRAINT `orders_shoppingcarts_Id` FOREIGN KEY (`shoppingCartId`) REFERENCES `shoppingcarts` (`id`);

--
-- Constraints for table `shoppingcartproducts`
--
ALTER TABLE `shoppingcartproducts`
  ADD CONSTRAINT `ShoppingCartProduct_Product_Id` FOREIGN KEY (`productId`) REFERENCES `products` (`id`),
  ADD CONSTRAINT `ShoppingCartProduct_ShoppingCart_Id` FOREIGN KEY (`shoppingCartId`) REFERENCES `shoppingcarts` (`id`);
SET FOREIGN_KEY_CHECKS=1;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
