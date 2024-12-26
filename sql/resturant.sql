CREATE DATABASE RestaurantDB;
USE RestaurantDB;

-- Table for Employees
CREATE TABLE Employees (
    EmployeeID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Position VARCHAR(50),
    PhoneNumber VARCHAR(15),
    Email VARCHAR(100)
);

-- Table for Menu Items
CREATE TABLE MenuItems (
    MenuItemID INT AUTO_INCREMENT PRIMARY KEY,
    ItemName VARCHAR(100),
    Price DECIMAL(10, 2),
    Description TEXT
);

-- Table for Orders
CREATE TABLE Orders (
    OrderID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerName VARCHAR(100),
    CustomerPhone VARCHAR(15),
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Table for Order Delivery
CREATE TABLE OrderDelivery (
    DeliveryID INT AUTO_INCREMENT PRIMARY KEY,
    OrderID INT,
    EmployeeID INT,
    DeliveryAddress TEXT,
    DeliveryStatus ENUM('Pending', 'In Transit', 'Delivered', 'Cancelled') DEFAULT 'Pending',
    DeliveryDate DATETIME,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE SET NULL
);

-- Table for Payments
CREATE TABLE Payments (
    PaymentID INT AUTO_INCREMENT PRIMARY KEY,
    OrderID INT,
    PaymentMethod ENUM('Cash', 'Credit Card', 'Online') DEFAULT 'Cash',
    PaymentStatus ENUM('Pending', 'Completed', 'Failed') DEFAULT 'Pending',
    PaymentDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE
);


-- Table for Order Details (relation between Orders and Menu Items)
CREATE TABLE OrderDetails (
    OrderDetailID INT AUTO_INCREMENT PRIMARY KEY,
    OrderID INT,
    MenuItemID INT,
    Quantity INT,
    Price DECIMAL(10, 2),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (MenuItemID) REFERENCES MenuItems(MenuItemID) ON DELETE CASCADE
);


Create Table Suppliers(
    SupplierID INT AUTO_INCREMENT PRIMARY KEY,
    SupplierName VARCHAR(100),
    ContactNumber VARCHAR(15),
    Email VARCHAR(100)
);

Create Table SupplierOrders(
    SupplierOrderID INT AUTO_INCREMENT PRIMARY KEY,
    SupplierID INT,
    EmployeeID INT,
    SupplyID INT,
    TotalCost DECIMAL(10, 2),
    Quantity INT,
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID) ON DELETE CASCADE,
    FOREIGN KEY (SupplYID) REFERENCES Supplies(SupplyID) ON DELETE CASCADE,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE SET NULL
);

Create Table Supplies(
    SupplyID INT AUTO_INCREMENT PRIMARY KEY,
    ItemName VARCHAR(100),
    Cat VARCHAR(100)
);



