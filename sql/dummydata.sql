USE RestaurantDB;

-- Insert dummy data into Employees table
INSERT INTO Employees (FirstName, LastName, Position, PhoneNumber, Email) VALUES
('John', 'Doe', 'Manager', '1234567890', 'john.doe@example.com'),
('Jane', 'Smith', 'Chef', '0987654321', 'jane.smith@example.com'),
('Alice', 'Johnson', 'Delivery Driver', '1112223333', 'alice.johnson@example.com'),
('Alice', 'Johnson', 'Delivery Driver', '1112223333', 'alice.johnson@example.com');

-- Insert dummy data into MenuItems table
INSERT INTO MenuItems (ItemName, Price, Description) VALUES
('Burger', 10.00, 'Delicious beef burger'),
('Pizza', 15.00, 'Cheesy pepperoni pizza'),
('Pasta', 12.00, 'Creamy Alfredo pasta');

-- Insert dummy data into Orders table
INSERT INTO Orders (CustomerName, CustomerPhone, OrderDate) VALUES
('Michael Brown', '2223334444', '2023-01-01 10:00:00'),
('Emily Davis', '5556667777', '2023-01-02 11:00:00');

-- Insert dummy data into OrderDelivery table
INSERT INTO OrderDelivery (OrderID, EmployeeID, DeliveryAddress, DeliveryStatus, DeliveryDate) VALUES
(1, 1, '123 Main St', 'Delivered', '2023-01-01 12:00:00'),
(2, 2, '456 Elm St', 'In Transit', '2023-01-02 13:00:00');

-- Insert dummy data into Payments table
INSERT INTO Payments (OrderID, PaymentMethod, PaymentStatus, PaymentDate) VALUES
(1, 'Credit Card', 'Completed', '2023-01-01 10:30:00'),
(2, 'Cash', 'Pending', '2023-01-02 11:30:00');

-- Insert dummy data into OrderDetails table
INSERT INTO OrderDetails (OrderID, MenuItemID, Quantity, Price) VALUES
(1, 1, 2, 20.00), -- 2 Burgers for OrderID 1
(1, 3, 1, 12.00), -- 1 Pasta for OrderID 1
(2, 2, 3, 45.00), -- 3 Pizzas for OrderID 2
(2, 1, 1, 10.00); -- 1 Burger for OrderID 2

-- Insert dummy data into Suppliers table
INSERT INTO Suppliers (SupplierName, ContactNumber, Email) VALUES
('Supplier One', '1234567890', 'supplier1@example.com'),
('Supplier Two', '0987654321', 'supplier2@example.com');

-- Insert dummy data into SupplierOrders tablea into Supplies table
INSERT INTO Supplies (ItemName, Cat) VALUES
('Tomatoes', 'Vegetables'),
('Cheese', 'Dairy');
INSERT INTO SupplierOrders (SupplierID, EmployeeID, SupplyID, TotalCost, Quantity, OrderDate) VALUES
(1, 1, 1, 100.50, 10, '2023-01-01 10:00:00'),
(2, 2, 2, 200.75, 20, '2023-01-02 11:00:00');

-- Insert dummy dat